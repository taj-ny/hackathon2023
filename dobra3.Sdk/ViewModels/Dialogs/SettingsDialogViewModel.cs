using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using dobra3.Sdk.AppModels;
using dobra3.Sdk.Services;
using dobra3.Shared.Api;

namespace dobra3.Sdk.ViewModels.Dialogs
{
    public sealed partial class SettingsDialogViewModel : ObservableObject
    {
        private IFileExplorerService FileExplorerService { get; } = Ioc.Default.GetRequiredService<IFileExplorerService>();

        [ObservableProperty] private string? _OpenAiKey;
        [ObservableProperty] private string? _QuestionsFileName;

        public SettingsDialogViewModel()
        {
            OpenAiKey = GameStateModel.OpenAiKey ?? ApiKeys.GetOpenAiKey();
            QuestionsFileName = GameStateModel.QuestionsFilePath is not null ? Path.GetFileName(GameStateModel.QuestionsFilePath) : "Używanie domyślnych pytań";
        }

        [RelayCommand]
        private async Task SelectQuestionsFileAsync()
        {
            GameStateModel.QuestionsFilePath = await FileExplorerService.PickFileAsync(".json");
            QuestionsFileName = GameStateModel.QuestionsFilePath is not null ? Path.GetFileName(GameStateModel.QuestionsFilePath) : "Używanie domyślnych pytań";
        }

        partial void OnOpenAiKeyChanged(string? value)
        {
            GameStateModel.OpenAiKey = value;
        }
    }
}
