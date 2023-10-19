using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.Services;
using dobra3.Sdk.ViewModels.Dialogs;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class LiveLineViewModel : ObservableObject
    {
        private IDialogService DialogService { get; } = Ioc.Default.GetRequiredService<IDialogService>();

        [ObservableProperty] private bool _IsVoteUsed;
        [ObservableProperty] private bool _IsSplitUsed;
        [ObservableProperty] private bool _IsCallUsed;
        [ObservableProperty] private bool _DisplayVotingResults;

        private QuestionViewModel _CurrentQuestion;
        public QuestionViewModel? CurrentQuestion
        {
            get => _CurrentQuestion;
            set
            {
                _CurrentQuestion = value;
                DisplayVotingResults = false;
            }
        }
        
        public ObservableCollection<string> Votes { get; }
        
        public LiveLineViewModel()
        {
            Votes = new() { "0%", "0%", "0%", "0%" };
        }

        [RelayCommand]
        private async Task VoteAsync()
        {
            if (IsVoteUsed)
                return;
            
            var votes = new Dictionary<AnswerViewModel, int>();
            foreach (var answer in CurrentQuestion.Answers)
                votes.Add(answer, 0);

            var remainingVotes = 100;
            if (Random.Shared.Next(0, 10) <= 7) // 80%
            {
                // Vote for correct answer
                var correctAnswerVotes = Random.Shared.Next(60, 80);
                remainingVotes -= correctAnswerVotes;
                votes[votes.First(x => x.Key.IsCorrect).Key] = correctAnswerVotes;
            }
            else
            {
                // Vote for the correct answer and one incorrect answer
                var answers = votes.Keys.ToList()
                    .Where(x => !x.IsCorrect)
                    .OrderBy(x => Guid.NewGuid().ToString())
                    .ToList();
                votes[votes.Keys.First(x => x.IsCorrect)] = Random.Shared.Next(30, 45);
                votes[answers[0]] = Random.Shared.Next(30, 45);

                remainingVotes -= votes[answers[0]] + votes[answers[1]];
            }
            
            // Randomly distribute remaining votes
            while (remainingVotes > 0)
            {
                var votesToAdd = Random.Shared.Next(1, 5);
                if (votesToAdd > remainingVotes)
                    votesToAdd = remainingVotes;
                    
                votes[votes.ElementAt(Random.Shared.Next(0, votes.Count)).Key] += votesToAdd;
                remainingVotes -= votesToAdd;
            }
            
            for (var i = 0; i < votes.Count; i++)
                Votes[i] = $"{votes.ElementAt(i).Value}%";

            DisplayVotingResults = true;
            IsVoteUsed = true;
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
            var viewModel = new ChatDialogViewModel();
            await viewModel.InitAsync();

            await DialogService.ShowChatDialogAsync(viewModel);
            IsCallUsed = true;
        }
    }
}