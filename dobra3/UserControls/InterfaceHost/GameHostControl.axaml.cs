using Avalonia.Controls;
using dobra3.Sdk.ViewModels;

namespace dobra3.UserControls.InterfaceHost
{
    public partial class GameHostControl : UserControl
    {
        public GameHostViewModel ViewModel
        {
            get => (GameHostViewModel)DataContext;
            set => DataContext = value;
        }

        public GameHostControl()
        {
            InitializeComponent();
        }
    }
}
