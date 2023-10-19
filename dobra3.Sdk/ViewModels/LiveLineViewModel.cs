using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class LiveLineViewModel : ObservableObject
    {
        [ObservableProperty] private bool _IsVoteUsed;
        [ObservableProperty] private bool _IsSplitUsed;
        [ObservableProperty] private bool _IsCallUsed;

        public QuestionViewModel? CurrentQuestion { get; set; }

        private async Task VoteAsync()
        {
        }
        
        [RelayCommand]
        private async Task SplitAsync()
        {
            if (IsSplitUsed)
                return;
            
            var incorrectAnswers = CurrentQuestion.Answers.Where(x => !x.IsCorrect).ToList();
            incorrectAnswers.RemoveAt(Random.Shared.Next(0, incorrectAnswers.Count()));
            foreach (var answer in incorrectAnswers)
                answer.IsExcluded = true;

            IsSplitUsed = true;
        }

        [RelayCommand]
        private async Task CallAsync()
        {
        }
    }
}