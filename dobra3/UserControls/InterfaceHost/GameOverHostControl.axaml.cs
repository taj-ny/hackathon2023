using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using dobra3.Sdk.ViewModels;

namespace dobra3.UserControls.InterfaceHost
{
    public partial class GameOverHostControl : UserControl
    {
        public GameOverViewModel ViewModel
        {
            get => (GameOverViewModel)DataContext;
            set => DataContext = value;
        }

        public static readonly StyledProperty<GameOverViewModel> ViewModelProperty =
            AvaloniaProperty.Register<GameHostControl, GameOverViewModel>(nameof(ViewModel));
        
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