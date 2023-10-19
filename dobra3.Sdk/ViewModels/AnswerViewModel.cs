using CommunityToolkit.Mvvm.ComponentModel;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class AnswerViewModel : ObservableObject
    {
        [ObservableProperty] private bool _IsCorrect;
        [ObservableProperty] private bool _IsSelected;
        [ObservableProperty] private string _Text;
    }
}
