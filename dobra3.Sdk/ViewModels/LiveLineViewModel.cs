using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class LiveLineViewModel : ObservableObject
    {
        [ObservableProperty] private bool _IsVoteUsed;
        [ObservableProperty] private bool _IsSplitUsed;
        [ObservableProperty] private bool _IsCallUsed;

        private async Task VoteAsync()
        {
        }
        
        [RelayCommand]
        private async Task SplitAsync()
        {
        }

        [RelayCommand]
        private async Task CallAsync()
        {
        }
    }
}