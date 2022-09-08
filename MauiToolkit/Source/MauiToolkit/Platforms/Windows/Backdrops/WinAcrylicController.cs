using MauiToolkit.Configurations;
using MauiToolkit.Core.Platforms.Windows.Extensions;
using MauiToolkit.Interop.Platforms.Windows.Primitives;
using WinRT;
using MicrosoftBackdrops = Microsoft.UI.Composition.SystemBackdrops;
using MicrosoftuiComposition = Microsoft.UI.Composition;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Platforms.Windows.Backdrops;
internal class WinAcrylicController : IDisposable
{
    public WinAcrylicController(MicrosoftuiXaml.Window window, BackdropConfigurations config)
    {
        ArgumentNullException.ThrowIfNull(config, nameof(config));
        ArgumentNullException.ThrowIfNull(window, nameof(window));

        if (!MicrosoftBackdrops.DesktopAcrylicController.IsSupported())
            return;

        _Config = config;
        _Window = window;

        var maker = SystemDispatcherQueue.Make();
        maker.EnsureWindowsSystemDispatcherQueueController();

        _SystemBackdropConfiguration = new()
        {
            IsInputActive = true,
            IsHighContrast = config.IsHighContrast,
            HighContrastBackgroundColor = config.HighContrastBackgroundColor?.ToPlatformColor(),
        };

        _AcrylicController = new()
        {
            LuminosityOpacity = config.LuminosityOpacity,
            TintOpacity = config.TintOpacity,
            TintColor = config.TintColor.ToPlatformColor(),
        };

        LoadTheme();
        var iCompositionSupportsSystemBackdrop = window.As<MicrosoftuiComposition.ICompositionSupportsSystemBackdrop>();
        _AcrylicController.AddSystemBackdropTarget(iCompositionSupportsSystemBackdrop);
        _AcrylicController.SetSystemBackdropConfiguration(_SystemBackdropConfiguration);

        config.PropertyChanged += Config_PropertyChanged;

        var application = Application.Current;
        if (application is not null)
            application.RequestedThemeChanged += Application_RequestedThemeChanged;

        window.Activated += Window_Activated;
    }

    MicrosoftuiXaml.Window? _Window;
    BackdropConfigurations? _Config;
    MicrosoftBackdrops.DesktopAcrylicController? _AcrylicController;
    MicrosoftBackdrops.SystemBackdropConfiguration? _SystemBackdropConfiguration;

    private void Config_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_SystemBackdropConfiguration is null)
            return;

        if (_AcrylicController is null)
            return;

        if (_Config is null)
            return;

        _SystemBackdropConfiguration.IsHighContrast = _Config.IsHighContrast;
        _SystemBackdropConfiguration.HighContrastBackgroundColor = _Config.HighContrastBackgroundColor?.ToPlatformColor();

        _AcrylicController.LuminosityOpacity = _Config.LuminosityOpacity;
        _AcrylicController.TintOpacity = _Config.TintOpacity;
        _AcrylicController.TintColor = _Config.TintColor.ToPlatformColor();
    }

    private void Application_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        if (_SystemBackdropConfiguration is null)
            return;

        switch (e.RequestedTheme)
        {
            case AppTheme.Unspecified:
                _SystemBackdropConfiguration.Theme = MicrosoftBackdrops.SystemBackdropTheme.Default;
                break;
            case AppTheme.Light:
                _SystemBackdropConfiguration.Theme = MicrosoftBackdrops.SystemBackdropTheme.Light;
                break;
            case AppTheme.Dark:
                _SystemBackdropConfiguration.Theme = MicrosoftBackdrops.SystemBackdropTheme.Dark;
                break;
            default:
                break;
        }
    }

    private void Window_Activated(object sender, MicrosoftuiXaml.WindowActivatedEventArgs args)
    {
        if (_SystemBackdropConfiguration is null)
            return;

        _SystemBackdropConfiguration.IsInputActive = args.WindowActivationState != MicrosoftuiXaml.WindowActivationState.Deactivated;
    }

    bool LoadTheme()
    {
        if (_SystemBackdropConfiguration is null)
            return false;

        var application = Application.Current;
        if (application is null)
            return false;

        switch (application.RequestedTheme)
        {
            case AppTheme.Unspecified:
                _SystemBackdropConfiguration.Theme = MicrosoftBackdrops.SystemBackdropTheme.Default;
                break;
            case AppTheme.Light:
                _SystemBackdropConfiguration.Theme = MicrosoftBackdrops.SystemBackdropTheme.Light;
                break;
            case AppTheme.Dark:
                _SystemBackdropConfiguration.Theme = MicrosoftBackdrops.SystemBackdropTheme.Dark;
                break;
            default:
                break;
        }

        return true;
    }

    public void Dispose()
    {
        if (_Window is not null)
        {
            _Window.Activated -= Window_Activated;
            _Window = default;
        }

        if (_Config is not null)
        {
            _Config.PropertyChanged -= Config_PropertyChanged;
            _Config = default;
        }

        var application = Application.Current;
        if (application is not null)
            application.RequestedThemeChanged -= Application_RequestedThemeChanged;

        _AcrylicController?.Dispose();
        _AcrylicController = default;

        _SystemBackdropConfiguration = default;
    }
}
