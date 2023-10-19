using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using dobra3.Sdk.Services;
using dobra3.Shared.Utils;

namespace dobra3.Sdk.ViewModels
{
    public sealed class MainViewModel : ObservableObject, IAsyncInitialize
    {
        public INavigationService HostNavigationService { get; } = Ioc.Default.GetRequiredService<INavigationService>();

        public Task InitAsync(CancellationToken cancellationToken = default)
        {
            HostNavigationService.NavigateAsync(new MenuHostViewModel(HostNavigationService));
            return Task.CompletedTask;
        }
    }
}
