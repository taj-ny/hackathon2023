using dobra3.Sdk.ViewModels.Dialogs;

namespace dobra3.Sdk.Services
{
    public interface IDialogService
    {
        Task ShowSettingsDialogAsync(SettingsDialogViewModel viewModel);

        Task ShowFriendDialogAsync();
    }
}
