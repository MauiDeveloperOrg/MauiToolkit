using System.Runtime.InteropServices;
using UIKit;

namespace MauiToolkit.Compositions;

public partial class MauiEffect
{
    UIVisualEffectView? _UIVisualEffectView;

    partial void OnAttaching(VisualElement view)
    {

    }

    partial void OnAttached()
    {
        Loaded();
    }

    partial void OnDetaching()
    {
        _UIVisualEffectView?.Dispose();
        _UIVisualEffectView = default;
    }

    partial void OnDetached(VisualElement view)
    {

    }

    partial void Loaded()
    {
        var platformView = _View?.Handler?.PlatformView as UIView;
        if (platformView is null)
            return;

        if (_UIVisualEffectView is null)
        {
            var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
            var visualEffectView = new UIVisualEffectView(blurEffect)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            _UIVisualEffectView = visualEffectView;
        }

        if (TintLuminosityOpacity != null)
            _UIVisualEffectView.Alpha = new NFloat(TintLuminosityOpacity.Value);

        platformView.BackgroundColor = UIColor.Clear;
        foreach (var item in platformView.Subviews)
        {
            if (item.Equals(_UIVisualEffectView))
                return;
        }

        platformView.AddSubview(_UIVisualEffectView);
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (_UIVisualEffectView is null)
            return;

        switch (propertyName)
        {
            case nameof(TintLuminosityOpacity):
                if (TintLuminosityOpacity != null)
                    _UIVisualEffectView.Alpha = new NFloat(TintLuminosityOpacity.Value);
                break;
            default:
                break;
        }
    }
}
