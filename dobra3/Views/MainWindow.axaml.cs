using Avalonia.Controls;
using dobra3.Sdk.ViewModels;

namespace dobra3.Views
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel
        {
            get => (MainViewModel)DataContext;
            set => ViewModel = value;
        }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new();
        }
    }
}