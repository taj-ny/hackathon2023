using Avalonia.Threading;
using dobra3.Sdk.Enums;
using dobra3.Sdk.Services;
using dobra3.Shared.Utils;
using dobra3.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dobra3.ServiceImplementation
{
    /// <inheritdoc cref="INavigationService"/>
    public interface INavigationControlContract
    {
        /// <summary>
        /// Sets the control used for navigation.
        /// </summary>
        public INavigationControl? NavigationControl { set; }
    }

    /// <inheritdoc cref="INavigationService"/>
    public sealed class AvaloniaNavigationService : INavigationControlContract, INavigationService
    {
        /// <inheritdoc/>
        public INavigationControl? NavigationControl { get; set; }

        /// <inheritdoc/>
        public INavigationTarget? CurrentTarget { get; protected set; }

        /// <inheritdoc/>
        public ICollection<INavigationTarget> Targets { get; protected set; }

        /// <inheritdoc/>
        public bool IsInitialized => NavigationControl is not null;

        /// <inheritdoc/>
        public event EventHandler<INavigationTarget?>? NavigationChanged;

        public AvaloniaNavigationService()
        {
            Targets = new List<INavigationTarget>();
        }

        /// <inheritdoc/>
        public async Task<bool> NavigateAsync(INavigationTarget target)
        {
            if (!IsInitialized)
                return false;

            CurrentTarget?.OnNavigatingFrom();
            target.OnNavigatingTo(NavigationType.Detached);

            var navigationResult = await BeginNavigationAsync(target, NavigationType.Detached);
            if (!navigationResult)
                return false;

            CurrentTarget = target;
            if (!Targets.Contains(target))
            {
                Targets.Add(target);
                if (target is IAsyncInitialize asyncInitialize)
                    _ = asyncInitialize.InitAsync();
            }

            NavigationChanged?.Invoke(this, target);
            return true;
        }

        /// <inheritdoc/>
        public async Task<bool> GoBackAsync()
        {
            if (!IsInitialized)
                return false;

            CurrentTarget?.OnNavigatingFrom();
            var navigationResult = await BeginNavigationAsync(null, NavigationType.Backward);
            if (navigationResult)
                NavigationChanged?.Invoke(this, CurrentTarget);

            return navigationResult;
        }

        /// <inheritdoc/>
        public async Task<bool> GoForwardAsync()
        {
            if (!IsInitialized)
                return false;

            CurrentTarget?.OnNavigatingFrom();
            var navigationResult = await BeginNavigationAsync(null, NavigationType.Forward);
            if (navigationResult)
                NavigationChanged?.Invoke(this, CurrentTarget);

            return navigationResult;
        }

        private async Task<bool> BeginNavigationAsync(INavigationTarget? target, NavigationType navigationType)
        {
            if (NavigationControl is null)
                return false;

            switch (navigationType)
            {
                case NavigationType.Backward:
                    {
                        return false;
                    }

                case NavigationType.Forward:
                    {
                        return false;
                    }

                default:
                case NavigationType.Detached:
                    {
                        if (target is null)
                            return false;

                        return await Dispatcher.UIThread.InvokeAsync(() => NavigationControl.NavigateAsync<INavigationTarget, object>(target, null));
                    }
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            CurrentTarget = null;
            NavigationControl?.Dispose();

            //Targets.DisposeCollection();
            Targets.Clear();
        }
    }
}
