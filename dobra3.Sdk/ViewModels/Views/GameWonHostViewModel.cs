using CommunityToolkit.Mvvm.ComponentModel;

namespace dobra3.Sdk.ViewModels.Views
{
    public sealed partial class GameWonHostViewModel : BasePageViewModel
    {
        [ObservableProperty] private decimal _WonAmount;
    }
}
