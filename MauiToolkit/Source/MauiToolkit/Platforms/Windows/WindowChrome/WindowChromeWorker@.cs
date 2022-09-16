using MauiToolkit.Core.Platforms.Windows.Extensions;
using MauiToolkit.Options;
using Microsoft.Maui.Platform;
using System.Reflection;
using MicrosoftuiXaml = Microsoft.UI.Xaml;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using MicrosoftuixamlControls = Microsoft.UI.Xaml.Controls;
using MicrosoftuixamlmediaImaging = Microsoft.UI.Xaml.Media.Imaging;
using Microsoftui = Microsoft.UI;
using Winui = Windows.UI;
using WinRT;
using MicrosoftuixamlData = Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Controls;

namespace MauiToolkit.Primitives;

internal partial class WindowChromeWorker
{
    private MicrosoftuiXaml.Thickness _NavigationViewContentMargin;
    public MicrosoftuiXaml.Thickness NavigationViewContentMargin
    {
        get => _NavigationViewContentMargin;
        set
        {
            _NavigationViewContentMargin = value;
            if (_Windowchrome.WindowTitleBarKind is WindowTitleBarKind.CustomTitleBarAndExtension or WindowTitleBarKind.PlatformDefault)
            {
                var navigationView = _WindowRootView?.NavigationViewControl;
                if (navigationView is null)
                    return;

                var thicknessProperty = typeof(RootNavigationView).GetProperty("NavigationViewContentMargin", BindingFlags.Instance | BindingFlags.NonPublic);
                if (thicknessProperty?.GetValue(navigationView) is MicrosoftuiXaml.Thickness thickness)
                {
                    if (thickness == new MicrosoftuiXaml.Thickness(0))
                        return;

                    thicknessProperty.SetValue(navigationView, new MicrosoftuiXaml.Thickness(0));
                }
            }
        }
    }

    bool LoadTitleBarColor(Color? background, Color? inactiveBackground, Color? foreground, Color? inactiveForeground)
    {
        var application = MicrosoftuiXaml.Application.Current;
        var resource = application.Resources;
        if (background != null)
            resource["WindowCaptionBackground"] = background.ToPlatform();

        if (inactiveBackground != null)
            resource["WindowCaptionBackgroundDisabled"] = inactiveBackground.ToPlatform();

        if (foreground != null)
            resource["WindowCaptionForeground"] = foreground.ToPlatform();

        if (inactiveForeground != null)
            resource["WindowCaptionForegroundDisabled"] = inactiveForeground.ToPlatform();

        //resource["TitleBarHeight"] = 50;

        //TriggertTitleBarRepaint();

        return true;
    }

    bool LoadTitleBarCorlor(MicrosoftuiWindowing.AppWindowTitleBar? titleBar)
    {
        if (titleBar is null)
            return false;

        var application = Application.Current;
        if (application is null)
            return false;

        AppTheme? theme = application.RequestedTheme;
        if (theme is null)
            return false;

        switch (theme)
        {
            case AppTheme.Dark:
                // Set active window colors
                titleBar.ForegroundColor = Microsoftui.Colors.White;
                titleBar.BackgroundColor = Microsoftui.Colors.Red;
                titleBar.ButtonForegroundColor = Microsoftui.Colors.White;
                titleBar.ButtonBackgroundColor = Microsoftui.Colors.Transparent;

                titleBar.ButtonHoverForegroundColor = Microsoftui.Colors.White;
                titleBar.ButtonHoverBackgroundColor = Microsoftui.Colors.BlueViolet;

                titleBar.ButtonPressedForegroundColor = Winui.Color.FromArgb(80, 255, 255, 255);
                titleBar.ButtonPressedBackgroundColor = Microsoftui.Colors.DarkSeaGreen;

                // Set inactive window colors
                titleBar.InactiveForegroundColor = Microsoftui.Colors.White;
                titleBar.InactiveBackgroundColor = null;

                titleBar.ButtonInactiveForegroundColor = Microsoftui.Colors.White;
                titleBar.ButtonInactiveBackgroundColor = Microsoftui.Colors.Transparent;
                break;
            default:
                // Set active window colors
                titleBar.ForegroundColor = Microsoftui.Colors.Black;
                titleBar.BackgroundColor = null;
                titleBar.ButtonForegroundColor = Microsoftui.Colors.Gray;
                titleBar.ButtonBackgroundColor = Microsoftui.Colors.Transparent;

                titleBar.ButtonHoverForegroundColor = Microsoftui.Colors.White;
                titleBar.ButtonHoverBackgroundColor = Microsoftui.Colors.BlueViolet;

                titleBar.ButtonPressedForegroundColor = Winui.Color.FromArgb(80, 255, 255, 255);
                titleBar.ButtonPressedBackgroundColor = Microsoftui.Colors.BlueViolet;

                // Set inactive window colors
                titleBar.InactiveForegroundColor = Microsoftui.Colors.Gainsboro;
                titleBar.InactiveBackgroundColor = null;
                titleBar.ButtonInactiveForegroundColor = Microsoftui.Colors.AliceBlue;
                titleBar.ButtonInactiveBackgroundColor = Microsoftui.Colors.Transparent;
                break;
        }

        //titleBar.SetDragRectangles

        return true;
    }

    bool LoadAppTitleBar(double height, double fontSize)
    {
        var propertyInfo = typeof(WindowRootView).GetProperty("AppTitleBar", BindingFlags.Instance | BindingFlags.NonPublic);
        var titleBar = propertyInfo?.GetValue(_WindowRootView);
        if (titleBar is not MicrosoftuiXaml.FrameworkElement frameworkElement)
            return false;

        if (height > 0)
            frameworkElement.Height = height;

        if (fontSize > 0)
        {
            var textBlock = frameworkElement.GetFirstDescendant<MicrosoftuixamlControls.TextBlock>();
            if (textBlock is not null)
                textBlock.FontSize = fontSize;
        }

        return true;
    }

    bool LoadAppIcon(string? icon)
    {
        if (string.IsNullOrWhiteSpace(icon))
            return false;

        var propertyInfo1 = typeof(WindowRootView).GetProperty("AppFontIcon", BindingFlags.Instance | BindingFlags.NonPublic);
        if (propertyInfo1?.GetValue(_WindowRootView) is MicrosoftuixamlControls.Image image)
        {
            Uri imageUri = new(icon, UriKind.RelativeOrAbsolute);
            MicrosoftuixamlmediaImaging.BitmapImage imageBitmap = new(imageUri);
            image.Source = imageBitmap;
            image.Width = 25;
            image.Height = 25;
        }

        return true;
    }

    bool SwitchTitleBar(WindowTitleBarKind kind)
    {
        if (_Window is null)
            return false;

        if (_AppWindow is null)
            return false;

        if (_WindowRootView is null)
            return false;

        if (_IsTitleBarIsSet)
            _AppWindow.TitleBar?.ResetToDefault();

        var propertyInfo = typeof(WindowRootView).GetProperty("AppTitleBar", BindingFlags.Instance | BindingFlags.NonPublic);
        var titleBar = propertyInfo?.GetValue(_WindowRootView);
        if (titleBar is not MicrosoftuiXaml.FrameworkElement frameworkElement)
            return false;

        switch (kind)
        {
            case WindowTitleBarKind.PlatformDefault:
                {
                    _Window.ExtendsContentIntoTitleBar = false;
                    frameworkElement.Visibility = MicrosoftuiXaml.Visibility.Collapsed;

                    var navigationView = _WindowRootView.NavigationViewControl;
                    if (navigationView is not null)
                    {
                        var thicknessProperty = typeof(RootNavigationView).GetProperty("NavigationViewContentMargin", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (thicknessProperty?.GetValue(navigationView) is MicrosoftuiXaml.Thickness thickness)
                            thicknessProperty.SetValue(navigationView, new MicrosoftuiXaml.Thickness(0));
                    }

                }

                break;
            case WindowTitleBarKind.CustomTitleBarAndExtension:
                {
                    _Window.ExtendsContentIntoTitleBar = false;
                    frameworkElement.Visibility = MicrosoftuiXaml.Visibility.Collapsed;
                    LoadTitleBarCorlor(_AppWindow.TitleBar);

                    var navigationView = _WindowRootView.NavigationViewControl;
                    if (navigationView is not null)
                    {
                        var thicknessProperty = typeof(RootNavigationView).GetProperty("NavigationViewContentMargin", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (thicknessProperty?.GetValue(navigationView) is MicrosoftuiXaml.Thickness thickness)
                            thicknessProperty.SetValue(navigationView, new MicrosoftuiXaml.Thickness(0));
                    }

                    if (!MicrosoftuiWindowing.AppWindowTitleBar.IsCustomizationSupported())
                        break;

                    if (_AppWindow.TitleBar is null)
                        break;

                    _AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;
                    _AppWindow.TitleBar.PreferredHeightOption = MicrosoftuiWindowing.TitleBarHeightOption.Standard;
                    _AppWindow.TitleBar.IconShowOptions = MicrosoftuiWindowing.IconShowOptions.HideIconAndSystemMenu;
                }

                break;
            default:
                _Window.ExtendsContentIntoTitleBar = true;
                frameworkElement.Visibility = MicrosoftuiXaml.Visibility.Visible;
                break;
        }

        _IsTitleBarIsSet = true;
        return true;
    }

    bool SetButtonConfigrations(WindowButtonKind kind)
    {
        if (_AppWindow is null)
            return false;

        switch (kind)
        {
            case WindowButtonKind.Hide:
                var customOverlappedPresenter = MicrosoftuiWindowing.OverlappedPresenter.CreateForContextMenu();
                _AppWindow.SetPresenter(customOverlappedPresenter);
                break;
            case WindowButtonKind.Show:
                var mainOverlappedPresenter = MicrosoftuiWindowing.OverlappedPresenter.Create();
                _AppWindow.SetPresenter(mainOverlappedPresenter);
                break;
            default:
                {
                    if (_AppWindow.Presenter.Kind is not MicrosoftuiWindowing.AppWindowPresenterKind.Overlapped)
                        _AppWindow.SetPresenter(MicrosoftuiWindowing.AppWindowPresenterKind.Overlapped);

                    var overlappedPresenter = _AppWindow.Presenter.As<MicrosoftuiWindowing.OverlappedPresenter>();
                    if (overlappedPresenter is not null)
                    {
                        overlappedPresenter.IsMinimizable = kind.HasFlag(WindowButtonKind.EnableMinizable);
                        overlappedPresenter.IsMaximizable = kind.HasFlag(WindowButtonKind.EnableMaximizable);
                        overlappedPresenter.IsResizable = kind.HasFlag(WindowButtonKind.EnableResizable);
                    }
                }
                break;
        }

        return true;
    }

    bool SetBindingConfig()
    {
        var navigationView = _WindowRootView?.NavigationViewControl;
        if (navigationView is null)
            return false;

        var contentProperty = typeof(RootNavigationView).GetProperty("ContentGrid", BindingFlags.Instance | BindingFlags.NonPublic);
        if (contentProperty is null)
            return false;

        var contentGrid = contentProperty.GetValue(navigationView);
        if (contentGrid is not MicrosoftuiXaml.FrameworkElement frameworkELement)
            return false;

        MicrosoftuixamlData.Binding marginBinding = new();
        marginBinding.Source = this;
        marginBinding.Path = new MicrosoftuiXaml.PropertyPath("NavigationViewContentMargin");
        marginBinding.Mode = MicrosoftuixamlData.BindingMode.TwoWay;
        marginBinding.UpdateSourceTrigger = MicrosoftuixamlData.UpdateSourceTrigger.PropertyChanged;
        MicrosoftuixamlData.BindingOperations.SetBinding(frameworkELement, MicrosoftuiXaml.FrameworkElement.MarginProperty, marginBinding);

        return true;
    }

    bool RemoveBindingConfig()
    {
        var navigationView = _WindowRootView?.NavigationViewControl;
        if (navigationView is null)
            return false;

        var contentProperty = typeof(RootNavigationView).GetProperty("ContentGrid", BindingFlags.Instance | BindingFlags.NonPublic);
        if (contentProperty is null)
            return false;

        var contentGrid = contentProperty.GetValue(navigationView);
        if (contentGrid is not MicrosoftuiXaml.FrameworkElement frameworkELement)
            return false;

       
        return true;
    }
}
