using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class QuestionViewModel : ObservableObject
    {
        [ObservableProperty] private string _Title;
        [ObservableProperty] private decimal _Amount;
        [ObservableProperty] private ObservableCollection<AnswerViewModel> _Answers;
    }
}
