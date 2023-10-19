using CommunityToolkit.Mvvm.ComponentModel;
using dobra3.Shared.Utils;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.DataModels;
using dobra3.Shared.Api;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace dobra3.Sdk.ViewModels.Dialogs
{
    public sealed partial class ChatDialogViewModel : ObservableObject, IAsyncInitialize
    {
        private readonly PeriodicTimer _periodicTimer;

        [ObservableProperty] private int _CurrentTime;

        private QuestionViewModel _question;
        
        public ObservableCollection<ChatBubbleViewModel> Bubbles { get; }

        public ChatDialogViewModel(QuestionViewModel question)
        {
            Bubbles = new();
            _question = question;
            _CurrentTime = 60;
            _periodicTimer = new(TimeSpan.FromMilliseconds(1000));
        }

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            _ = BeginTimerAsync(cancellationToken);
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
            if (string.IsNullOrEmpty(query))
                return;

            var bubble = new ChatBubbleViewModel();
            bubble.Message = await CallFriend(_question);
            Bubbles.Add(bubble);
        }
        
        public async Task<string> CallFriend(QuestionViewModel qs)
        {
            var api = new OpenAI_API.OpenAIAPI(ApiKeys.GetOpenAiKey());
            try { 
                var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
                {
                    Model = Model.ChatGPTTurbo,
                    Temperature = 0.1,
                    MaxTokens = 100,
                    Messages = new ChatMessage[] {
                        new ChatMessage(ChatMessageRole.User, "Na pytanie `" + qs.Title + "` są cztery odpowiedzi: Odpowiedź A: " + qs.Answers[0].Text + ", B: " + qs.Answers[1].Text + ", C: " + qs.Answers[2].Text + ", D: " + qs.Answers[3].Text + ", Udawaj osobę która musi wybrać jedno z nich, nawet jak jesteś pewien odpowiedzi to używaj zwrotów `myślę, że`, `wydaje mi się że` itd. NIE wspominaj o byciu modelem SI, odpowiadaj krótko. Jeśli nie znasz odpowiedzi na pytanie to przyznaj się do swojej niewiedzy ale i tak wytypuj 1 z odpowiedzi jako najbardziej prawdopodobną. Jak znasz poprawną odpowiedź to uzasadnij w krótki sposób dlaczego ją wybrałeś.")
                    }
                });
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> QuestionFriend(string question)
        {
            var api = new OpenAI_API.OpenAIAPI(ApiKeys.GetOpenAiKey());
            try
            {
                var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
                {
                    Model = Model.ChatGPTTurbo,
                    Temperature = 0.1,
                    MaxTokens = 100,
                    Messages = new ChatMessage[] {
                        new ChatMessage(ChatMessageRole.User, question)
                    }
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
