using CommunityToolkit.Mvvm.ComponentModel;
using dobra3.Shared.Utils;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using dobra3.Shared.Api;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace dobra3.Sdk.ViewModels.Dialogs
{
    public sealed partial class ChatDialogViewModel : ObservableObject, IAsyncInitialize
    {
        private readonly PeriodicTimer _periodicTimer;
        private readonly List<ChatMessage> _messages;

        [ObservableProperty] private int _CurrentTime;
        [ObservableProperty] private bool _IsWritingResponse;

        private QuestionViewModel _question;
        
        public ObservableCollection<ChatBubbleViewModel> Bubbles { get; }

        public ChatDialogViewModel(QuestionViewModel question)
        {
            Bubbles = new();
            _question = question;
            _CurrentTime = 60;
            _periodicTimer = new(TimeSpan.FromMilliseconds(1000));
            _messages = new()
            {
                new ChatMessage(ChatMessageRole.System, "Na pytanie `" + _question.Title + "` są cztery odpowiedzi: Odpowiedź A: " + _question.Answers[0].Text + ", B: " + _question.Answers[1].Text + ", C: " + _question.Answers[2].Text + ", D: " + _question.Answers[3].Text + ", Udawaj osobę która musi wybrać jedno z nich, nawet jak jesteś pewien odpowiedzi to używaj zwrotów `myślę, że`, `wydaje mi się że` itd. NIE wspominaj o byciu modelem SI, odpowiadaj krótko. Jeśli nie znasz odpowiedzi na pytanie to przyznaj się do swojej niewiedzy ale i tak wytypuj 1 z odpowiedzi jako najbardziej prawdopodobną. Jak znasz poprawną odpowiedź to uzasadnij w krótki sposób dlaczego ją wybrałeś.")
            };
        }

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            _ = BeginTimerAsync(cancellationToken);
            _ = SendAsync(null);
            return Task.CompletedTask;
        }

        private async Task BeginTimerAsync(CancellationToken cancellationToken)
        {
            while (await _periodicTimer.WaitForNextTickAsync(cancellationToken))
            {
                CurrentTime--;

                if (CurrentTime <= 0)
                {
                    _periodicTimer.Dispose();
                }
            }
        }

        [RelayCommand]
        private async Task SendAsync(string? query)
        {
            IsWritingResponse = true;
            if (_messages.Count > 1 && query is null)
                return;

            ChatBubbleViewModel bubble;
            if (query is not null)
            {
                bubble = new ChatBubbleViewModel();
                bubble.Message = query;
                Bubbles.Add(bubble);
                _messages.Add(new ChatMessage(ChatMessageRole.User, bubble.Message));
            }

            bubble = new ChatBubbleViewModel();
            bubble.Message = await QuestionFriend();
            Bubbles.Add(bubble);
            _messages.Add(new ChatMessage(ChatMessageRole.Assistant, bubble.Message));
            IsWritingResponse = false;
        }

        private async Task<string> QuestionFriend()
        {
            var api = new OpenAI_API.OpenAIAPI(ApiKeys.GetOpenAiKey());
            try
            {
                var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
                {
                    Model = Model.ChatGPTTurbo,
                    Temperature = 0.1,
                    MaxTokens = 100,
                    Messages = _messages
                });
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
