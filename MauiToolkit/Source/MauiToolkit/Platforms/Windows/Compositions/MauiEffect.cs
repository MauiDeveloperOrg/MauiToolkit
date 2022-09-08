using MauiToolkit.Core.Platforms.Windows.Extensions;
using Microsoft.Maui.Controls;
using Microsoft.UI.Xaml.Media;
using PlatformControls = Microsoft.UI.Xaml.Controls;
using PlatformSharps = Microsoft.UI.Xaml.Shapes;
using PlatformXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Compositions;

public partial class MauiEffect
{
    AcrylicBrush? _PlatformAcrylicBrush = default;

    partial void OnAttaching(VisualElement view)
    {
         
    }

    partial void OnAttached()
    {
        Loaded();
    }

    partial void OnDetaching()
    {
         
    }

    partial void OnDetached(VisualElement view)
    {
         
    }

    partial void Loaded()
    {
        if (_View?.Handler?.PlatformView is null)
            return;

        var platformView = _View.Handler.PlatformView;

        _PlatformAcrylicBrush ??= new()
        {
            TintColor = TintColor.ToPlatformColor(),
            TintLuminosityOpacity = TintLuminosityOpacity,
            TintOpacity = TintOpacity,
            FallbackColor = FallbackColor.ToPlatformColor(),
        };

        if (platformView is PlatformSharps.Shape shape)
            shape.Fill = _PlatformAcrylicBrush;
        else if (platformView is PlatformControls.Panel panel)
            panel.Background = _PlatformAcrylicBrush;
        else if (platformView is PlatformControls.Control control)
            control.Background = _PlatformAcrylicBrush;
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (_PlatformAcrylicBrush is null)
            return;

        switch (propertyName)
        {
            case nameof(TintColor):
                _PlatformAcrylicBrush.TintColor = TintColor.ToPlatformColor();
                break;
            case nameof(TintOpacity):
                _PlatformAcrylicBrush.TintOpacity = TintOpacity;
                break;
            case nameof(TintLuminosityOpacity):
                _PlatformAcrylicBrush.TintLuminosityOpacity = TintLuminosityOpacity;
                break;
            case nameof(FallbackColor):
                _PlatformAcrylicBrush.FallbackColor = FallbackColor.ToPlatformColor();
                break;
            default:
                break;
        }
    }
}
