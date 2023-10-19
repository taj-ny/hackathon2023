using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using dobra3.Sdk.ViewModels.Dialogs;

namespace dobra3.Views.Dialogs
{
    public partial class ChatDialogWindow : Window
    {
        public ChatDialogViewModel ViewModel
        {
            get => (ChatDialogViewModel)DataContext;
            set
            {
                DataContext = value;
                value.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == nameof(ViewModel.CurrentTime))
                    {
                        if (ViewModel.CurrentTime == 0)
                            Close();
                    }
                };
            }
        }

        public static readonly StyledProperty<ChatDialogViewModel> ViewModelProperty =
            AvaloniaProperty.Register<ChatDialogWindow, ChatDialogViewModel>(nameof(ViewModel));

        public ChatDialogWindow()
        {
            InitializeComponent();
        }

        private async void InputElement_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && sender is TextBox textBox)
            {
                await ViewModel.SendCommand.ExecuteAsync(textBox.Text);
            }
        }
    }
}
