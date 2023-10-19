using Avalonia;
using Avalonia.Controls;
using dobra3.Sdk.ViewModels.Views;

namespace dobra3.UserControls.InterfaceHost
{
    public partial class MenuHostControl : UserControl
    {
        public MenuHostViewModel ViewModel
        {
            get => (MenuHostViewModel)DataContext;
            set => DataContext = value;
        }
        
        public static readonly StyledProperty<MenuHostViewModel> ViewModelProperty =
            AvaloniaProperty.Register<GameHostControl, MenuHostViewModel>(nameof(ViewModel));

        public MenuHostControl()
        {
            InitializeComponent();
        }
    }
}
