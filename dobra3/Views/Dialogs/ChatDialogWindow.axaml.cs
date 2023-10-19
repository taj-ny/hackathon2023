using Avalonia;
using Avalonia.Controls;
using dobra3.Sdk.ViewModels.Dialogs;

namespace dobra3.Views.Dialogs
{
    public partial class ChatDialogWindow : Window
    {
        public ChatDialogViewModel ViewModel
        {
            get => (ChatDialogViewModel)DataContext;
            set => DataContext = value;
        }

        public static readonly StyledProperty<ChatDialogViewModel> ViewModelProperty =
            AvaloniaProperty.Register<ChatDialogWindow, ChatDialogViewModel>(nameof(ViewModel));

        public ChatDialogWindow()
        {
            InitializeComponent();
        }
    }
}
