﻿using MauiToolkit.Primitives;
using MauiToolkit.Providers;
using MauiToolkit.Service;

namespace MauiToolkit;

// All the code in this file is included in all platforms.
public static class WindowStartupExtensions
{
    public static Window UseWindowStartup(this Window window) => window.UseWindowStartup(default);

    public static Window UseWindowStartup(this Window window, Action<WindowStartup>? configureDelegate)
    {
        var windowStartup = new WindowStartup();
        configureDelegate?.Invoke(windowStartup);
        WindowStartup.SetWindowStartup(window, windowStartup);
        return window;
    }

    public static IWindowStartupService? GetWindowStartupService(this Window window)
    {
        if (window == null)
            return default;

        var worker = WindowStartup.GetWindowStartup(window);
        if (worker is not IProvider<IWindowStartupService> provider)
            return default;

        return provider.GetService();
    }

    public static IWindowStartupService? GetWindowStartupService()
    {
        var window = Application.Current?.Windows?.FirstOrDefault();
        if (window is null)
            return default;

        return GetWindowStartupService(window);
    }
}
