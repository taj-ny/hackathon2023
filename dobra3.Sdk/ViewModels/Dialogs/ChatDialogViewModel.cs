using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.AppModels;
using dobra3.Sdk.Enums;
using dobra3.Shared.Utils;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using dobra3.Sdk.Services;

namespace dobra3.Sdk.ViewModels.Dialogs
{
    public sealed partial class ChatDialogViewModel : ObservableObject, IAsyncInitialize
    {
        private readonly PeriodicTimer _periodicTimer;
        private readonly List<ChatMessage> _messages;
        private readonly QuestionViewModel _question;
        private readonly SemaphoreSlim _semaphore;

        [ObservableProperty] private int _CurrentTime;
        [ObservableProperty] private bool _IsWritingResponse;

        private IDialogService DialogService { get; } = Ioc.Default.GetRequiredService<IDialogService>();

        public ObservableCollection<ChatBubbleViewModel> Bubbles { get; }

        public ChatDialogViewModel(QuestionViewModel question)
        {
            Bubbles = new();
            _question = question;
            _CurrentTime = 60;
            _periodicTimer = new(TimeSpan.FromMilliseconds(1000));
            _semaphore = new(1, 1);
            _messages = new()
            {
                new ChatMessage(ChatMessageRole.System, "Na pytanie `" + _question.Title + "` są cztery odpowiedzi: Odpowiedź A: " + _question.Answers[0].Text + ", B: " + _question.Answers[1].Text + ", C: " + _question.Answers[2].Text + ", D: " + _question.Answers[3].Text + ", Udawaj osobę która musi wybrać jedno z nich, nawet jak jesteś pewien odpowiedzi to używaj zwrotów `myślę, że`, `wydaje mi się że` itd. NIE wspominaj o byciu modelem SI, odpowiadaj krótko. Jeśli nie znasz odpowiedzi na pytanie to przyznaj się do swojej niewiedzy ale i tak wytypuj 1 z odpowiedzi jako najbardziej prawdopodobną. Jak znasz poprawną odpowiedź to uzasadnij w krótki sposób dlaczego ją wybrałeś.")
            };
        }

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            Bubbles.Add(new()
            {
                Message = $"Hej! Dzownię ze studia Milionerów i mam problem z pytaniem: '{_question.Title}'\nA: {_question.Answers[0].Text}\nB: {_question.Answers[1].Text}\nC: {_question.Answers[2].Text}\nD: {_question.Answers[3].Text}\n\nCzy mógłbyś mi w tym pomóc?",
                SenderType = SenderType.Player
            });

            _ = BeginTimerAsync(cancellationToken);
            _ = SendAsync(null);
            return Task.CompletedTask;
        }

        private async Task BeginTimerAsync(CancellationToken cancellationToken)
        {
            while (await _periodicTimer.WaitForNextTickAsync(cancellationToken))
            {
                await _semaphore.WaitAsync();
                CurrentTime--;

                if (CurrentTime <= 0)
                {
                    _periodicTimer.Dispose();
                }
                _semaphore.Release();
            }
        }

        [RelayCommand]
        private async Task OpenSettingsAsync()
        {
            await _semaphore.WaitAsync();
            await DialogService.ShowSettingsDialogAsync(new());
            _semaphore.Release();
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
                bubble = new ChatBubbleViewModel
                {
                    Message = query,
                    SenderType = SenderType.Player
                };
                Bubbles.Add(bubble);
                _messages.Add(new ChatMessage(ChatMessageRole.User, bubble.Message));
            }

            bubble = new ChatBubbleViewModel
            {
                Message = await QuestionFriend(),
                SenderType = SenderType.Friend
            };
            Bubbles.Add(bubble);
            _messages.Add(new ChatMessage(ChatMessageRole.Assistant, bubble.Message));
            IsWritingResponse = false;
        }

        private async Task<string> QuestionFriend()
        {
            var api = new OpenAI_API.OpenAIAPI(GameStateModel.OpenAiKey);
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
