using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using dobra3.Sdk.ViewModels.Views;

namespace dobra3.UserControls.InterfaceHost
{
    public partial class GameOverHostControl : UserControl
    {
        public GameOverHostViewModel ViewModel
        {
            get => (GameOverHostViewModel)DataContext;
            set => DataContext = value;
        }

        public static readonly StyledProperty<GameOverHostViewModel> ViewModelProperty =
            AvaloniaProperty.Register<GameHostControl, GameOverHostViewModel>(nameof(ViewModel));
        
        public GameOverHostControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}