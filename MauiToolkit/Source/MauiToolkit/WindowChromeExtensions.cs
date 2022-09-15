using MauiToolkit.Providers;
using MauiToolkit.Service;

namespace MauiToolkit;

public static class WindowChromeExtensions
{
    public static Window UseWindowChrome(this Window window) => window.UseWindowChrome(default);

    public static Window UseWindowChrome(this Window window, Action<WindowChrome>? configureDelegate) 
    {
        var windowChrome = new WindowChrome();
        configureDelegate?.Invoke(windowChrome);
        WindowChrome.SetWindowChrome(window, windowChrome);
        return window;
    }

    public static IWindowChromeService? GetWindowStartupService(this Window window)
    {
        if (window == null)
            return default;

        var worker = WindowChrome.GetWindowChrome(window);
        if (worker is not IProvider<IWindowChromeService> provider)
            return default;

        return provider.GetService();
    }

    public static IWindowChromeService? GetWindowStartupService()
    {
        var window = Application.Current?.Windows?.FirstOrDefault();
        if (window is null)
            return default;

        return GetWindowStartupService(window);
    }
}
