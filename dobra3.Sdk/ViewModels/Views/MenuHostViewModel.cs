using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.AppModels;
using dobra3.Sdk.DataModels;
using dobra3.Sdk.Services;
using dobra3.Shared.Extensions;
using System.Reflection;

namespace dobra3.Sdk.ViewModels.Views
{
    public sealed partial class MenuHostViewModel : BasePageViewModel
    {
        private readonly INavigationService _navigationService;

        private IDialogService DialogService { get; } = Ioc.Default.GetRequiredService<IDialogService>();

        public MenuHostViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task StartGameAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(GameStateModel.QuestionsFilePath) || FileExtensions.TryOpenRead(GameStateModel.QuestionsFilePath) is not { } stream)
                stream = Assembly.GetEntryAssembly()!.GetManifestResourceStream("dobra3.Assets.DefaultQuestions.TestQuestions.json");

            if (stream is null)
                return;

            var questions = await StreamSerializer.Instance.TryDeserializeAsync<QuestionSetDataModel, Stream>(stream, cancellationToken);
            if (questions is null)
                return;

            await _navigationService.NavigateAsync(new GameHostViewModel(_navigationService, questions));
        }

        [RelayCommand]
        private async Task OpenSettingsAsync()
        {
            await DialogService.ShowSettingsDialogAsync(new());
        }
    }
}
