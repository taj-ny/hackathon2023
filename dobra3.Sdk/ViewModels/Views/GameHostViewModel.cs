using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.DataModels;
using dobra3.Sdk.Services;
using dobra3.Shared.Utils;

namespace dobra3.Sdk.ViewModels.Views
{
    public sealed partial class GameHostViewModel : BasePageViewModel, IAsyncInitialize
    {
        private readonly INavigationService _navigationService;
        private readonly QuestionSetDataModel _questions;
        
        private int _questionIndex;

        [ObservableProperty] private ObservableCollection<QuestionViewModel> _Questions;
        [ObservableProperty] private QuestionViewModel? _CurrentQuestion;

        public LiveLineViewModel LiveLineViewModel { get; set; }

        public GameHostViewModel(INavigationService navigationService, QuestionSetDataModel questions)
        {
            _navigationService = navigationService;
            _questions = questions;
            _Questions = new();
            LiveLineViewModel = new();
        }

        partial void OnCurrentQuestionChanged(QuestionViewModel? value)
        {
            LiveLineViewModel.CurrentQuestion = value;
        }

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in _questions.Questions)
            {
                Questions.Add(new QuestionViewModel()
                {
                    Title = item.Question,
                    Amount = 1m,
                    Answers = new(item.Answers.Select(x => new AnswerViewModel() { Text = x.Answer, IsCorrect = x.IsCorrect}))
                });
            }

            CurrentQuestion = Questions[_questionIndex];
            return Task.CompletedTask;
        }


        [RelayCommand]
        public async Task A_AnswerAsync()
        {
            await AnswerAsync(0);
        }

        [RelayCommand]
        public async Task B_AnswerAsync()
        {
            await AnswerAsync(1);
        }

        [RelayCommand]
        public async Task C_AnswerAsync()
        {
            await AnswerAsync(2);
        }

        [RelayCommand]
        public async Task D_AnswerAsync()
        {
            await AnswerAsync(3);
        }

        private async Task AnswerAsync(int index)
        {
            if (CurrentQuestion is null)
                return;

            var answer = CurrentQuestion.Answers[index];
            answer.IsSelected = true;

            // Pressure wait
            await Task.Delay(1000);

            if (!answer.IsCorrect)
                await _navigationService.NavigateAsync(new GameOverHostViewModel());
            else
            {
                _questionIndex++;

                if (_questionIndex >= Questions.Count)
                    await _navigationService.NavigateAsync(new GameWonHostViewModel() { WonAmount = 10m });
                else
                    CurrentQuestion = Questions[_questionIndex];
            }
        }
    }
}
