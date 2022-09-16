using MauiToolkit.Configurations;
using MauiToolkit.Core.Platforms.Windows.Extensions;
using MauiToolkit.Interop.Platforms.Windows.Primitives;
using MicrosoftBackdrops = Microsoft.UI.Composition.SystemBackdrops;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Platforms.Windows.Backdrops;
internal abstract class BackdropController : IDisposable
{
    public BackdropController(MicrosoftuiXaml.Window window, BackdropConfigurations config)
    {
        ArgumentNullException.ThrowIfNull(config, nameof(config));
        ArgumentNullException.ThrowIfNull(window, nameof(window));

        if (!IsSupported())
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

        OnDetaching(_SystemBackdropConfiguration);
        LoadTheme();

        config.PropertyChanged += Config_PropertyChanged;

        var application = Application.Current;
        if (application is not null)
            application.RequestedThemeChanged += Application_RequestedThemeChanged;

        window.Activated += Window_Activated;
    }

    protected MicrosoftuiXaml.Window? _Window;
    protected BackdropConfigurations? _Config;
    private MicrosoftBackdrops.SystemBackdropConfiguration? _SystemBackdropConfiguration;

    public void Dispose()
    {
        Disposing();

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

        _SystemBackdropConfiguration = default;
    }

    protected abstract bool IsSupported();
    protected abstract bool OnDetaching(MicrosoftBackdrops.SystemBackdropConfiguration systemConfiguration);
    protected abstract bool PropertyChanged();
    protected abstract bool Disposing();

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

    void Config_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_SystemBackdropConfiguration is null)
            return;

        if (_Config is null)
            return;

        _SystemBackdropConfiguration.IsHighContrast = _Config.IsHighContrast;
        _SystemBackdropConfiguration.HighContrastBackgroundColor = _Config.HighContrastBackgroundColor?.ToPlatformColor();

        PropertyChanged();
    }

    void Window_Activated(object sender, MicrosoftuiXaml.WindowActivatedEventArgs args)
    {
        if (_SystemBackdropConfiguration is null)
            return;

        _SystemBackdropConfiguration.IsInputActive = args.WindowActivationState != MicrosoftuiXaml.WindowActivationState.Deactivated;
    }

    void Application_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
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


}
