using MauiToolkit.Core.Extensions;
using MauiToolkit.Core.Platforms.Windows.Extensions;
using MauiToolkit.Options;
using Microsoft.Maui.Platform;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Primitives;

internal partial class WindowChromeWorker
{
    MicrosoftuiXaml.Window? _Window;
    MicrosoftuiWindowing.AppWindow? _AppWindow;
    WindowRootView? _WindowRootView;

    Page? _MainPage;
    bool _IsMainPageLoaded = false;
    bool _IsTitleBarIsSet = false;

    bool _IsLastFullScreen = false;

    partial void OnAttaching(Window window)
    {

    }

    partial void OnAttached()
    {
        Loaded();
    }

    partial void OnDetaching()
    {
        var application = Application.Current;
        if (application is not null)
            application.RequestedThemeChanged -= Application_RequestedThemeChanged;

        if (_AppWindow is not null)
            _AppWindow.Changed -= AppWindow_Changed;

        if (_MainPage is not null)
            _MainPage.Loaded -= MainPage_Loaded;

        RemoveBindingConfig();

        _IsMainPageLoaded = false;
        _MainPage = default;
        _AppWindow = default;
        _WindowRootView = default;
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

        var application = Application.Current;
        if (application is not null)
            application.RequestedThemeChanged += Application_RequestedThemeChanged;

        if (_AppWindow is not null)
            _AppWindow.Changed += AppWindow_Changed;

        var mauiContext = _AssociatedObject?.Page?.RequireMauiContext();
        if (mauiContext is not null)
            _WindowRootView = mauiContext.GetNavigationRootManager().RootView as WindowRootView;

        var mainPage = Application.Current?.MainPage;
        if (mainPage is not null)
        {
            mainPage.Loaded += MainPage_Loaded;
            _MainPage = mainPage;
        }

        LoadTitleBarColor(_Windowchrome.CaptionActiveBackgroundColor, _Windowchrome.CaptionInactiveBackgroundColor, _Windowchrome.CaptionActiveForegroundColor, _Windowchrome.CaptionInactiveForegroundColor);
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
            case nameof(WindowChrome.CaptionHeight):
            case nameof(WindowChrome.TitleFontSize):
                LoadAppTitleBar(_Windowchrome.CaptionHeight, _Windowchrome.TitleFontSize);
                break;
            case nameof(WindowChrome.WindowTitleBarKind):
                SwitchTitleBar(_Windowchrome.WindowTitleBarKind);
                break;
            case nameof(WindowChrome.WindowButtonKind):
                SetButtonConfigrations(_Windowchrome.WindowButtonKind);
                break;
            default:
                break;
        }

    }

    private void AppWindow_Changed(MicrosoftuiWindowing.AppWindow sender, MicrosoftuiWindowing.AppWindowChangedEventArgs args)
    {
        if (!args.DidPresenterChange)
            return;

        if (_IsLastFullScreen)
            SetButtonConfigrations(_Windowchrome.WindowButtonKind);

        if (sender.Presenter.Kind == MicrosoftuiWindowing.AppWindowPresenterKind.FullScreen)
            _IsLastFullScreen = true;
        else
            _IsLastFullScreen = false;
    }

    private void MainPage_Loaded(object? sender, EventArgs e)
    {
        if (_IsMainPageLoaded)
            return;

        LoadAppTitleBar(_Windowchrome.CaptionHeight, _Windowchrome.TitleFontSize);
        LoadAppIcon(_Windowchrome.Icon);
        SwitchTitleBar(_Windowchrome.WindowTitleBarKind);

        if (_Windowchrome.WindowTitleBarKind is not WindowTitleBarKind.Default or WindowTitleBarKind.DefaultWithExtension)
            SetButtonConfigrations(_Windowchrome.WindowButtonKind);

        SetBindingConfig();


        _IsMainPageLoaded = true;
    }

    private void Application_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        LoadTitleBarCorlor(_AppWindow?.TitleBar);
    }
}
