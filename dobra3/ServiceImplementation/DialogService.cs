using dobra3.Sdk.Services;
using dobra3.Views;
using dobra3.Views.Dialogs;
using System;
using System.Threading.Tasks;

namespace dobra3.ServiceImplementation
{
    internal sealed class DialogService : IDialogService
    {
        public Task ShowSettingsDialogAsync()
        {
            var settingsDialog = new SettingsDialogWindow();
            return settingsDialog.ShowDialog(MainWindow.Instance);
        }

        public Task ShowFriendDialogAsync()
        {
            throw new NotImplementedException();
        }
    }
}
