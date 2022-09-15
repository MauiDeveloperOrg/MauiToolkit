using Foundation;
using MauiToolkit.Interop.Platforms.MacCatalyst.Extensions;
using MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.Appkit.Notifications;
using UIKit;

namespace MauiToolkit.Primitives;

internal partial class WindowStartupWorker
{
    bool _IsLoaded = false;
    UIWindow? _Window;
    //NSObject? _NsApplication;
    NSObject? _NsWindow;
    IDisposable? _NSApplicationDidFinishRestoring;

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
        if (window?.Handler?.PlatformView is not UIWindow platformWindow)
            return;

        if (_NsWindow is not null)
            return;

        _Window = platformWindow;

        if (!_IsLoaded)
        {
            _NSApplicationDidFinishRestoring = NsApplication_Notifications.NSApplicationDidFinishRestoringWindows((s, e) =>
            {
                if (_NsWindow is not null)
                    return;

                var nsWindow = platformWindow.GetHostWidnowForUiWindow();
                if (nsWindow is null)
                    return;

                _NsWindow = nsWindow;
            });

            _IsLoaded = true;
        }

        var nsWindow = platformWindow.GetHostWidnowForUiWindow();
        if (nsWindow is null)
            return;

        _NsWindow = nsWindow;

        LoadBackgroundMaterial(_WindowStartup.BackdropsKind, _WindowStartup.BackdropConfigurations);
        MoveWindow(_WindowStartup.WindowPresenterKind);
    }

    partial void Destroying()
    {

    }

    partial void Stopped()
    {
        _NSApplicationDidFinishRestoring?.Dispose();
        _NsWindow = default;
        _Window = default;
        _IsLoaded = false;
    }

    partial void PropertyChanged(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        switch (name)
        {
            case nameof(WindowStartup.Width):
            case nameof(WindowStartup.Height):
            case nameof(WindowStartup.WindowPresenterKind):
            case nameof(WindowStartup.WindowAlignment):
            case nameof(WindowStartup.IsShowFllowMouse):
                MoveWindow(_WindowStartup.WindowPresenterKind);
                break;
            case nameof(WindowStartup.BackdropsKind):
            case nameof(WindowStartup.BackdropConfigurations):
                LoadBackgroundMaterial(_WindowStartup.BackdropsKind, _WindowStartup.BackdropConfigurations);
                break;
            default:
                break;
        }
    }
}
