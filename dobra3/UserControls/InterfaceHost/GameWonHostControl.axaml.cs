using Avalonia;
using Avalonia.Controls;
using dobra3.Sdk.ViewModels;
using dobra3.Sdk.ViewModels.Views;

namespace dobra3.UserControls.InterfaceHost
{
    public partial class GameWonHostControl : UserControl
    {
        public GameWonHostViewModel ViewModel
        {
            get => (GameWonHostViewModel)DataContext;
            set => DataContext = value;
        }

        public static readonly StyledProperty<GameWonHostViewModel> ViewModelProperty =
            AvaloniaProperty.Register<GameWonHostControl, GameWonHostViewModel>(nameof(ViewModel));

        public GameWonHostControl()
        {
            InitializeComponent();
        }
    }
}
