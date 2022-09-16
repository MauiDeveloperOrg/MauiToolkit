using MauiToolkit.Configurations;
using MauiToolkit.Core.Platforms.Windows.Extensions;
using MauiToolkit.Interop.Platforms.Windows.Primitives;
using WinRT;
using MicrosoftBackdrops = Microsoft.UI.Composition.SystemBackdrops;
using MicrosoftuiComposition = Microsoft.UI.Composition;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Platforms.Windows.Backdrops;
internal class WinMicaController : BackdropController
{
    public WinMicaController(MicrosoftuiXaml.Window window, BackdropConfigurations config) :base(window, config)
    {
       

    }

    MicrosoftBackdrops.MicaController? _MicaController;

    protected override bool IsSupported() => MicrosoftBackdrops.MicaController.IsSupported();

    protected override bool OnDetaching(MicrosoftBackdrops.SystemBackdropConfiguration systemConfiguration)
    {
        if (_Config is null)
            return false;

        _MicaController = new()
        {
            Kind = _Config.IsUseBaseKind ? MicrosoftBackdrops.MicaKind.Base : MicrosoftBackdrops.MicaKind.BaseAlt,
            LuminosityOpacity = _Config.LuminosityOpacity,
            TintOpacity = _Config.TintOpacity,
            TintColor = _Config.TintColor.ToPlatformColor(),
        };

        var iCompositionSupportsSystemBackdrop = _Window?.As<MicrosoftuiComposition.ICompositionSupportsSystemBackdrop>();
        if (iCompositionSupportsSystemBackdrop is null)
            return false;

        _MicaController.AddSystemBackdropTarget(iCompositionSupportsSystemBackdrop);
        _MicaController.SetSystemBackdropConfiguration(systemConfiguration);

        return true;

    }

    protected override bool PropertyChanged()
    {
        if (_MicaController is null)
            return false;

        if (_Config is null)
            return false;

        _MicaController.Kind = _Config.IsUseBaseKind ? MicrosoftBackdrops.MicaKind.Base : MicrosoftBackdrops.MicaKind.BaseAlt;
        _MicaController.LuminosityOpacity = _Config.LuminosityOpacity;
        _MicaController.TintOpacity = _Config.TintOpacity;
        _MicaController.TintColor = _Config.TintColor.ToPlatformColor();

        return true;
    }

    protected override bool Disposing()
    {
        _MicaController?.Dispose();
        _MicaController = default;
        return true;
    }
}
