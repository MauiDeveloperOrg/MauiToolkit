using MauiToolkit.Service;

namespace MauiToolkit.Helpers;
public class PlatformHelpers
{
    //internal static IService? GetPlatformWindowChromeSevice(Window window, WindowChrome windowChrome)
    //{
    //    if (window is null)
    //        return default;

    //    if (window.Handler is null)
    //        return default;

    //    return new WindowChromeService(window, windowChrome);
    //}

    internal static IService? GetPlatformWindowStartupSevice(Window window, WindowStartup windowStartup)
    {
        if (window is null)
            return default;

        if (window.Handler is null)
            return default;

        return new WindowStartupService(window, windowStartup);
    }

    //internal static IService? GetPlatformWindowStartupSevice(Window window, IElementHandler handler, WindowStartup windowStartup)
    //{
    //    if (window is null)
    //        return default;

    //    if (handler is null)
    //        return default;

    //    return new WindowStartupService(window, handler, windowStartup);
    //}

    //internal static IService? GetShellViewService(Window window, ShellFrame shellView)
    //{
    //    if (window is null)
    //        return default;

    //    if (window.Handler is null)
    //        return default;

    //    return new ShellViewService(window, shellView);
    //}

}
