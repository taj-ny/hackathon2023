using dobra3.Sdk.Services;
using dobra3.Views;
using dobra3.Views.Dialogs;
using System;
using System.Threading.Tasks;
using dobra3.Sdk.ViewModels.Dialogs;

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

        public Task ShowFriendDialogAsync()
        {
            throw new NotImplementedException();
        }
    }
}
