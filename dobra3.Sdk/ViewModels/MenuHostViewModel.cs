using System.Reflection;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.AppModels;
using dobra3.Sdk.DataModels;
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
            using var stream = Assembly.GetEntryAssembly()!.GetManifestResourceStream("dobra3.Assets.DefaultQuestions.TestQuestions.json");
            var questions = (QuestionSetDataModel?)await StreamSerializer.Instance.DeserializeAsync(stream, typeof(QuestionSetDataModel), cancellationToken);
            
            await _navigationService.NavigateAsync(new GameHostViewModel(questions));
        }
    }
}
