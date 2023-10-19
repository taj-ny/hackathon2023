using Avalonia.Controls;
using Avalonia.Interactivity;
using dobra3.Helpers;
using dobra3.Sdk.ViewModels;

namespace dobra3.UserControls.InterfaceRoot
{
    public partial class MainWindowRootControl : UserControl
    {
        public MainViewModel ViewModel
        {
            get => (MainViewModel)DataContext;
            set => ViewModel = value;
        }

        public MainWindowRootControl()
        {
            InitializeComponent();

            ViewModel = new();
        }

        private async void Control_Loaded(object? sender, RoutedEventArgs e)
        {
            ViewModel.HostNavigationService.SetupNavigation(Navigation);
            await ViewModel.InitAsync();
        }
    }
}
