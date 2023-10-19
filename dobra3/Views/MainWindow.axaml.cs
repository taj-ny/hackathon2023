using Avalonia.Controls;

namespace dobra3.Views
{
    public partial class MainWindow : Window
    {
        private static MainWindow? _Instance;
        public static MainWindow Instance => _Instance ??= new();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}