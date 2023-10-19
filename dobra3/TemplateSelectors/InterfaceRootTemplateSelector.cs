using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using dobra3.Sdk.ViewModels.Views;
using System.ComponentModel;

namespace dobra3.TemplateSelectors
{
    public sealed class InterfaceRootTemplateSelector : GenericTemplateSelector<INotifyPropertyChanged>
    {
        public DataTemplate? MenuHostTemplate { get; set; }
        public DataTemplate? GameHostTemplate { get; set; }
        public DataTemplate? GameOverHostTemplate { get; set; }
        public DataTemplate? GameWonHostTemplate { get; set; }

        protected override IDataTemplate? SelectTemplateCore(INotifyPropertyChanged? item)
        {
            return item switch
            {
                MenuHostViewModel => MenuHostTemplate,
                GameHostViewModel => GameHostTemplate,
                GameOverHostViewModel => GameOverHostTemplate,
                GameWonHostViewModel => GameWonHostTemplate
            };
        }
    }
}