using dobra3.Sdk.Services;
using dobra3.Sdk.ViewModels.Dialogs;
using dobra3.Views;
using dobra3.Views.Dialogs;
using System.Threading.Tasks;

namespace dobra3.ServiceImplementation
{
    internal sealed class DialogService : IDialogService
    {
        public Task ShowSettingsDialogAsync(SettingsDialogViewModel viewModel)
        {
            return new SettingsDialogWindow()
            {
                ViewModel = viewModel
            }.ShowDialog(MainWindow.Instance);
        }

        public Task ShowChatDialogAsync(ChatDialogViewModel viewModel)
        {
            return new ChatDialogWindow()
            {
                ViewModel = viewModel
            }.ShowDialog(MainWindow.Instance);
        }
    }
}
