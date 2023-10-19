using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using dobra3.Sdk.Services;
using dobra3.ServiceImplementation;
using dobra3.Views;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dobra3
{
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                _serviceProvider = ConfigureServices();
                Ioc.Default.ConfigureServices(_serviceProvider);

                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<INavigationService, AvaloniaNavigationService>()
                ;

            return serviceCollection.BuildServiceProvider();
        }
    }
}