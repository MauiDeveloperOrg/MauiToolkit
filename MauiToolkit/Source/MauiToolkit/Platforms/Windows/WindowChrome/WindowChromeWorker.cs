using MauiToolkit.Core.Extensions;
using MauiToolkit.Core.Platforms.Windows.Extensions;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Primitives;

internal partial class WindowChromeWorker
{
    MicrosoftuiXaml.Window? _Window;
    MicrosoftuiWindowing.AppWindow? _AppWindow;

    ShellView? _RootShellView;
    WindowRootView? _WindowRootView;

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
        _AppWindow = platformWindow.GetAppWindow();

        if (_AppWindow is not null)
            _AppWindow.Changed += AppWindow_Changed;

        var mauiContext = _AssociatedObject?.Page?.RequireMauiContext();
        if (mauiContext is not null)
        {
            var platformElement = window.Page?.ToPlatform() as ShellView;
            _RootShellView = platformElement;
            _WindowRootView = mauiContext.GetNavigationRootManager().RootView as WindowRootView;
        }

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

    private void AppWindow_Changed(MicrosoftuiWindowing.AppWindow sender, MicrosoftuiWindowing.AppWindowChangedEventArgs args)
    {

    }
}
