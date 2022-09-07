using MauiToolkit.Service;

namespace MauiToolkit;

internal partial class WindowStartupService : IService, IWindowStartupService
{
    public WindowStartupService(Window window, IWindowHandler handler, WindowStartup windowStartup) : this(window, windowStartup)
    {
        
    }

    public WindowStartupService(Window window, WindowStartup windowStartup)
    {
        ArgumentNullException.ThrowIfNull(window);
        ArgumentNullException.ThrowIfNull(windowStartup);
        _Window = window;
        _WindowStartup = windowStartup;
    }

    readonly Window _Window;
    readonly WindowStartup _WindowStartup;

  

    bool IService.Run()
    {
        throw new NotImplementedException();
    }

    bool IService.Stop()
    {
        throw new NotImplementedException();
    }
 
}
