using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.Services;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class MenuHostViewModel : BasePageViewModel
    {
        private INavigationService _navigationService;

        public MenuHostViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task StartGameAsync(CancellationToken cancellationToken)
        {
            await _navigationService.NavigateAsync(new GameHostViewModel());
        }
    }
}
