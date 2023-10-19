using CommunityToolkit.Mvvm.ComponentModel;
using dobra3.Shared.Utils;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace dobra3.Sdk.ViewModels.Dialogs
{
    public sealed partial class ChatDialogViewModel : ObservableObject, IAsyncInitialize
    {
        private readonly PeriodicTimer _periodicTimer;

        [ObservableProperty] private int _CurrentTime;
        
        public ObservableCollection<ChatBubbleViewModel> Bubbles { get; }

        public ChatDialogViewModel()
        {
            Bubbles = new()
            {
                new () { Message = "abc" },
                new () { Message = "abcasdasd" },
                new () { Message = "abcasdasdasaa" },
            };
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


        }
    }
}
