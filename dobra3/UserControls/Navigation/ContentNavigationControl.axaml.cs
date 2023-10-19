using Avalonia.Controls;
using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.Templates;

namespace dobra3.UserControls.Navigation
{
    public abstract partial class ContentNavigationControl : UserControl
    {
        public ContentNavigationControl()
        {
            InitializeComponent();
        }

        public virtual async Task<bool> NavigateAsync<TTarget, TTransition>(TTarget? target, TTransition? transition = default) where TTransition : class
        {
            // Get the transition finalizer which will be used to end the transition
            var transitionFinalizer = await ApplyTransitionAsync(target, transition);

            // Navigate by setting the content
            MainContent.Content = target;

            // End the transition
            if (transitionFinalizer is not null)
                await transitionFinalizer.DisposeAsync();

            return true;
        }

        protected abstract Task<IAsyncDisposable?> ApplyTransitionAsync<TTarget, TTransition>(TTarget? target, TTransition? transition = default) where TTransition : class;

        public IDataTemplate? TemplateSelector
        {
            get => (IDataTemplate?)GetValue(TemplateSelectorProperty);
            set => SetValue(TemplateSelectorProperty, value);
        }

        public static readonly StyledProperty<IDataTemplate> TemplateSelectorProperty =
            AvaloniaProperty.Register<ContentNavigationControl, IDataTemplate>(nameof(TemplateSelector));
    }
}
