using MauiToolkit.Configurations;
using MauiToolkit.Interop.Platforms.Windows.Runtimes.User32;
using MauiToolkit.Options;
using MauiToolkit.Platforms.Windows.Backdrops;
using Microsoft.Maui.Platform;
using PInvoke;
using static PInvoke.User32;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using WindowsGraphics = Windows.Graphics;

namespace MauiToolkit.Primitives;

internal partial class WindowStartupWorker
{
    bool SwitchBackdrop(BackdropsKind kind, BackdropConfigurations config)
    {
        _Backdrop?.Dispose();
        _Backdrop = default;

        if (_Window is null)
            return false;

        switch (kind)
        {
            case BackdropsKind.Default:
                break;
            case BackdropsKind.Mica:
                _Backdrop = new WinMicaController(_Window, config);
                break;
            case BackdropsKind.Acrylic:
                _Backdrop = new WinAcrylicController(_Window, config);
                break;
            case BackdropsKind.BlurEffect:
                break;
            default:
                break;
        }

        //TriggertTitleBarRepaint();
        return true;
    }

    bool ShownInSwitchers(bool isShownInSwitchers)
    {
        if (_AppWindow is null)
            return false;

        _AppWindow.IsShownInSwitchers = isShownInSwitchers;
        return true;
    }

    bool ShowInTopMost(bool isTopMost)
    {
        if (_AppWindow is null)
            return false;

        _AppWindow.MoveInZOrderAtTop();
        //_AppWindow.ShowOnceWithRequestedStartupState();
        return true;
    }

    bool ShowWindow(WindowPresenterKind kind, bool isFllowMouse, WindowAlignment alignment, Size size)
    {
        MoveWindow(isFllowMouse, alignment, size);
        ShowPresenter(kind);
        return true;
    }

    bool ShowPresenter(WindowPresenterKind kind)
    {
        switch (kind)
        {
            case WindowPresenterKind.Maximize:
                MaximizeWidnow();
                break;
            case WindowPresenterKind.Minimize:
                MiniaturizeWindow();
                break;
            case WindowPresenterKind.FullScreen:
                ToggleFullScreen(true);
                break;
            default:
                ToggleFullScreen(false);
                //MoveWindow(_WindowStartup.WindowAlignment, new Size(_WindowStartup.Width, _WindowStartup.Height));
                break;
        }

        return true;
    }

    bool MoveWindow(bool isFllowMouse, WindowAlignment alignment, Size size)
    {
        if (_Window is null)
            return false;

        if (_AppWindow is null)
            return false;

        var displyArea = MicrosoftuiWindowing.DisplayArea.Primary;
        //获取焦点屏幕 根据鼠标获取当前激活的屏幕
        if (isFllowMouse)
        {
            var vPoint = GetCursorPos();
            var vInt32Point = new WindowsGraphics.PointInt32(vPoint.x, vPoint.y);
            displyArea = MicrosoftuiWindowing.DisplayArea.GetFromPoint(vInt32Point, MicrosoftuiWindowing.DisplayAreaFallback.None);
        }

        double scalingFactor = _Window.GetDisplayDensity();

        var width = size.Width * scalingFactor;
        var height = size.Height * scalingFactor;

        if (width > displyArea.WorkArea.Width)
            width = displyArea.WorkArea.Width;

        if (height > displyArea.WorkArea.Height)
            height = displyArea.WorkArea.Height;

        double startX = 0;
        double startY = 0;

        switch (alignment)
        {
            case WindowAlignment.LeftTop:
                break;
            case WindowAlignment.RightTop:
                startX = (displyArea.WorkArea.Width - width);
                break;
            case WindowAlignment.Center:
                startX = (displyArea.WorkArea.Width - width) / 2.0;
                startY = (displyArea.WorkArea.Height - height) / 2.0;
                break;
            case WindowAlignment.LeftBottom:
                startY = (displyArea.WorkArea.Height - height);
                break;
            case WindowAlignment.RightBottom:
                startX = (displyArea.WorkArea.Width - width);
                startY = (displyArea.WorkArea.Height - height);
                break;
            default:
                break;
        }

        _AppWindow.MoveAndResize(new((int)startX, (int)startY, (int)width, (int)height), displyArea);
        return true;
    }

    bool MiniaturizeWindow()
    {
        if (_Window is null)
            return false;

        var windowHanlde = _Window.GetWindowHandle();
        PostMessage(windowHanlde, WindowMessage.WM_SYSCOMMAND, new IntPtr((int)SysCommands.SC_MINIMIZE), IntPtr.Zero);

        return true;
    }

    bool MaximizeWidnow()
    {
        if (_Window is null)
            return false;

        var windowHanlde = _Window.GetWindowHandle();
        PostMessage(windowHanlde, WindowMessage.WM_SYSCOMMAND, new IntPtr((int)SysCommands.SC_MAXIMIZE), IntPtr.Zero);

        return true;
    }

    bool ToggleFullScreen(bool bFullScreen)
    {
        if (_Window is null)
            return false;

        if (_AppWindow is null)
            return false;

        //var windowChrome = WindowChrome.GetWindowChrome(_Window);

        //if (bFullScreen)
        //{
        //    if (windowChrome is not null)
        //    {
        //        if (windowChrome.WindowTitleBarKind is WindowTitleBarKind.Default or WindowTitleBarKind.DefaultWithExtension)
        //            _Window.ExtendsContentIntoTitleBar = false;
        //    }


        //    if (_AppWindow.Presenter.Kind is not MicrosoftuiWindowing.AppWindowPresenterKind.FullScreen)
        //        _AppWindow.SetPresenter(MicrosoftuiWindowing.AppWindowPresenterKind.FullScreen);
        //}
        //else
        //{
        //    if (windowChrome is not null)
        //    {
        //        if (windowChrome.WindowTitleBarKind is WindowTitleBarKind.Default or WindowTitleBarKind.DefaultWithExtension)
        //            _Window.ExtendsContentIntoTitleBar = true;
        //    }

        //    if (_AppWindow.Presenter.Kind is MicrosoftuiWindowing.AppWindowPresenterKind.FullScreen)
        //    {
        //        var customOverlappedPresenter = MicrosoftuiWindowing.OverlappedPresenter.CreateForContextMenu();
        //        _AppWindow.SetPresenter(customOverlappedPresenter);
        //    }
        //}

        return true;
    }

    bool TriggertTitleBarRepaint()
    {
        if (_Window is null)
            return false;

        var windowHanlde = _Window.GetWindowHandle();
        var activeWindow = User32.GetActiveWindow();
        if (windowHanlde == activeWindow)
        {
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)User32Constants.WA_INACTIVE), IntPtr.Zero);
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)User32Constants.WA_ACTIVE), IntPtr.Zero);
        }
        else
        {
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)User32Constants.WA_ACTIVE), IntPtr.Zero);
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)User32Constants.WA_INACTIVE), IntPtr.Zero);
        }

        return true;
    }
}
