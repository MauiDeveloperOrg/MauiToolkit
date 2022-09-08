using Microsoft.Maui.Platform;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Primitives.WindowStrartup;

internal partial class WindowStartupWorker
{
    MicrosoftuiXaml.Window? _Window;
    MicrosoftuiWindowing.AppWindow? _AppWindow;

    partial void OnAttaching(Window window)
    {
         
    }

    partial void OnAttached()
    {
        Loaded();
    }

    partial void OnDetaching()
    {
         
    }

    partial void OnDetached(Window window)
    {
         
    }

    partial void Loaded()
    {
        var window = _AssociatedObject;
        if (window?.Handler?.PlatformView is not MicrosoftuiXaml.Window platformWindow)
            return;

        _Window = platformWindow;



    }

    partial void Destroying()
    {
        
    }

    partial void Stopped()
    {
        
    }

    partial void PropertyChanged(string name)
    {
         
    }
}
