using Microsoft.Maui.Platform;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Primitives;

internal partial class WindowStartupWorker
{
    MicrosoftuiXaml.Window? _Window;
    MicrosoftuiWindowing.AppWindow? _AppWindow;
    IDisposable? _Backdrop;

    partial void OnAttaching(Window window)
    {
         
    }

    partial void OnAttached()
    {
        Loaded();
    }

    partial void OnDetaching()
    {
        _Backdrop?.Dispose();
        _Backdrop = default;
        _Window = default;
        _AppWindow = default;
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

        SwitchBackdrop(_WindowStartup.BackdropsKind, _WindowStartup.BackdropConfigurations);
        ShownInSwitchers(_WindowStartup.ShowInSwitcher);
        ShowWindow(_WindowStartup.WindowPresenterKind, _WindowStartup.IsShowFllowMouse, _WindowStartup.WindowAlignment, new Size(_WindowStartup.Width, _WindowStartup.Height));
        ShowInTopMost(_WindowStartup.TopMost);

        return;
    }

    partial void Destroying()
    {
        OnDetaching();
    }

    partial void Stopped()
    {
        //OnDetaching();
    }

    partial void PropertyChanged(string name)
    {
        switch (name)
        {
            case nameof(WindowStartup.Width):
            case nameof(WindowStartup.Height):
            case nameof(WindowStartup.WindowPresenterKind):
            case nameof(WindowStartup.WindowAlignment):
            case nameof(WindowStartup.IsShowFllowMouse):
                ShowWindow(_WindowStartup.WindowPresenterKind, _WindowStartup.IsShowFllowMouse, _WindowStartup.WindowAlignment, new Size(_WindowStartup.Width, _WindowStartup.Height));
                break;
            case nameof(WindowStartup.ShowInSwitcher):
                ShownInSwitchers(_WindowStartup.ShowInSwitcher);
                break;
            case nameof(WindowStartup.BackdropsKind):
            case nameof(WindowStartup.BackdropConfigurations):
                SwitchBackdrop(_WindowStartup.BackdropsKind, _WindowStartup.BackdropConfigurations);
                break;
            case nameof(WindowStartup.TopMost):
                ShowInTopMost(_WindowStartup.TopMost);
                break;
            default:
                break;
        }
    }
}
