using Avalonia;
using Avalonia.Controls;
using dobra3.Sdk.ViewModels.Dialogs;

namespace dobra3.Views.Dialogs
{
    public partial class SettingsDialogWindow : Window
    {
        public SettingsDialogViewModel ViewModel
        {
            get => (SettingsDialogViewModel)DataContext;
            set => DataContext = value;
        }

        public static readonly StyledProperty<SettingsDialogViewModel> ViewModelProperty =
            AvaloniaProperty.Register<SettingsDialogWindow, SettingsDialogViewModel>(nameof(ViewModel));

        public SettingsDialogWindow()
        {
            InitializeComponent();
        }
    }
}
