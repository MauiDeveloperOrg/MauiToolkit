using MauiToolkit.Configurations;
using MauiToolkit.Core.Platforms.Windows.Extensions;
using WinRT;
using MicrosoftBackdrops = Microsoft.UI.Composition.SystemBackdrops;
using MicrosoftuiComposition = Microsoft.UI.Composition;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Platforms.Windows.Backdrops;
internal class WinAcrylicController : BackdropController
{
    public WinAcrylicController(MicrosoftuiXaml.Window window, BackdropConfigurations config) : base(window, config)
    {

    }

    MicrosoftBackdrops.DesktopAcrylicController? _AcrylicController;

    protected override bool IsSupported() => MicrosoftBackdrops.DesktopAcrylicController.IsSupported();

    protected override bool OnDetaching(MicrosoftBackdrops.SystemBackdropConfiguration systemConfiguration)
    {
        if (_Config is null)
            return false;

        _AcrylicController = new()
        {
            LuminosityOpacity = _Config.LuminosityOpacity,
            TintOpacity = _Config.TintOpacity,
            TintColor = _Config.TintColor.ToPlatformColor(),
        };

        var iCompositionSupportsSystemBackdrop = _Window?.As<MicrosoftuiComposition.ICompositionSupportsSystemBackdrop>();
        if (iCompositionSupportsSystemBackdrop is null)
            return false;
        _AcrylicController.AddSystemBackdropTarget(iCompositionSupportsSystemBackdrop);
        _AcrylicController.SetSystemBackdropConfiguration(systemConfiguration);

        return true;
    }

    protected override bool PropertyChanged()
    {
        if (_AcrylicController is null)
            return false;

        if (_Config is null)
            return false;

        _AcrylicController.LuminosityOpacity = _Config.LuminosityOpacity;
        _AcrylicController.TintOpacity = _Config.TintOpacity;
        _AcrylicController.TintColor = _Config.TintColor.ToPlatformColor();

        return true;
    }

    protected override bool Disposing()
    {
        _AcrylicController?.Dispose();
        _AcrylicController = default;
        return true;
    }
}
