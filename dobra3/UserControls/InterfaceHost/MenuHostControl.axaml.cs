using Avalonia.Controls;
using dobra3.Sdk.ViewModels;

namespace dobra3.InterfaceHost.UserControls
{
    public partial class MenuHostControl : UserControl
    {
        public MenuHostViewModel ViewModel
        {
            get => (MenuHostViewModel)DataContext;
            set => DataContext = value;
        }

        public MenuHostControl()
        {
            InitializeComponent();
        }
    }
}
