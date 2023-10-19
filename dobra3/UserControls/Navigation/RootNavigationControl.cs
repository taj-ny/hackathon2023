using System;
using System.Threading.Tasks;

namespace dobra3.UserControls.Navigation
{
    internal sealed class RootNavigationControl : ContentNavigationControl
    {
        protected override Task<IAsyncDisposable?> ApplyTransitionAsync<TTarget, TTransition>(TTarget? target, TTransition? transition = default) where TTarget : default where TTransition : class
        {
            return Task.FromResult<IAsyncDisposable?>(null);
        }
    }
}
