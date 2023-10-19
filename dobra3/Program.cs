﻿using Avalonia;
using Avalonia.ReactiveUI;
using Projektanker.Icons.Avalonia;
using System;
using Projektanker.Icons.Avalonia.FontAwesome;

namespace dobra3;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {

        IconProvider.Current
            .Register<FontAwesomeIconProvider>();


        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
    }

}