using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using dobra3.Utils;
using System;
using System.Threading.Tasks;

namespace dobra3.UserControls.Navigation
{
    public partial class ContentNavigationControl : UserControl
    {
        public ContentNavigationControl()
        {
            InitializeComponent();
        }

        public virtual async Task<bool> NavigateAsync<TTarget, TTransition>(TTarget? target, TTransition? transition = default) where TTransition : class
        {
            var transitionFinalizer = await ApplyTransitionAsync(target, transition);
            MainContent.Content = target;

            if (transitionFinalizer is not null)
                await transitionFinalizer.DisposeAsync();

            return true;
        }

        protected virtual Task<IAsyncDisposable?> ApplyTransitionAsync<TTarget, TTransition>(TTarget? target, TTransition? transition = default) where TTransition : class
        {
            return null;
        }

        public void Dispose()
        {
            (MainContent.Content as IDisposable)?.Dispose();
        }

        public IDataTemplate? TemplateSelector
        {
            get => (IDataTemplate?)GetValue(TemplateSelectorProperty);
            set => SetValue(TemplateSelectorProperty, value);
        }

        public static readonly StyledProperty<IDataTemplate> TemplateSelectorProperty =
            AvaloniaProperty.Register<ContentNavigationControl, IDataTemplate>(nameof(TemplateSelector));
    }
}
