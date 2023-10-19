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

        [ObservableProperty] private ObservableCollection<QuestionViewModel> _Questions;
        [ObservableProperty] private QuestionViewModel? _CurrentQuestion;

        private IEnumerator<QuestionViewModel> _questionsEnumerator;

        public LiveLineViewModel LiveLineViewModel { get; set; }

        public GameHostViewModel(INavigationService navigationService, QuestionSetDataModel questions)
        {
            _navigationService = navigationService;
            _questions = questions;
            _Questions = new();
            LiveLineViewModel = new();
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

            _questionsEnumerator = Questions.GetEnumerator();
            _questionsEnumerator.MoveNext();
            CurrentQuestion = Questions.FirstOrDefault();

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
            var answer = _CurrentQuestion.Answers[index];
            answer.IsSelected = true;

            await Task.Delay(1000);

            _questionsEnumerator.MoveNext();
            if (!answer.IsCorrect || _questionsEnumerator.Current is null)
                await _navigationService.NavigateAsync(new GameOverHostViewModel());
            else
                _CurrentQuestion = _questionsEnumerator.Current;
        }
    }
}
