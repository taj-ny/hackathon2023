using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.AppModels;
using dobra3.Sdk.DataModels;
using dobra3.Shared.Utils;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class GameHostViewModel : BasePageViewModel, IAsyncInitialize
    {
        private readonly QuestionSetDataModel _questions;

        [ObservableProperty] private ObservableCollection<QuestionViewModel> _Questions;
        [ObservableProperty] private QuestionViewModel? _CurrentQuestion;

        public GameHostViewModel(QuestionSetDataModel questions)
        {
            _questions = questions;
            _Questions = new();
        }

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in _questions.Questions)
            {
                Questions.Add(new QuestionViewModel()
                {
                    Title = item.Question,
                    Amount = 1m,
                    Answers = new(item.Answers.Select(x => new AnswerViewModel() { Text = x.Answer }))
                });
            }

            CurrentQuestion = Questions.FirstOrDefault();

            return Task.CompletedTask;
        }


        [RelayCommand]
        public async Task A_AnswerAsync()
        {

        }

        [RelayCommand]
        public async Task B_AnswerAsync()
        {

        }

        [RelayCommand]
        public async Task C_AnswerAsync()
        {

        }

        [RelayCommand]
        public async Task D_AnswerAsync()
        {

        }
    }
}
