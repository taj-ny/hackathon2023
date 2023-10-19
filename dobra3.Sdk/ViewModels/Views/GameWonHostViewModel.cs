using CommunityToolkit.Mvvm.ComponentModel;

namespace dobra3.Sdk.ViewModels.Views
{
    public sealed partial class GameWonHostViewModel : ObservableObject
    {
        [ObservableProperty] private decimal _WonAmount;
    }
}
