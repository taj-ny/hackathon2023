using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using dobra3.Shared.Utils;

namespace dobra3.Sdk.ViewModels.Dialogs
{
    public sealed partial class ChatDialogViewModel : ObservableObject, IAsyncInitialize
    {
        private readonly PeriodicTimer _periodicTimer;

        [ObservableProperty] private int _CurrentTime;

        public ChatDialogViewModel()
        {
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
            while (await _periodicTimer.WaitForNextTickAsync())
            {
                CurrentTime--;

                if (CurrentTime <= 0)
                {
                    _periodicTimer.Dispose();
                }
            }
        }
    }
}
