using CoreGraphics;
using Foundation;
using MauiToolkit.Configurations;
using MauiToolkit.Interop.Platforms.MacCatalyst.Helpers;
using MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.Appkit;
using MauiToolkit.Options;
using System.Runtime.InteropServices;
using UIKit;

namespace MauiToolkit.Primitives;

internal partial class WindowStartupWorker : NSObject
{
    readonly double _ScalingFactorX = 1.0d;
    readonly double _ScalingFactorY = 1.0d;

    bool LoadBackgroundMaterial(BackdropsKind kind, BackdropConfigurations options)
    {
        if (_Window is null)
            return false;

        if (_NsWindow is null)
            return false;

        switch (kind)
        {
            case BackdropsKind.BlurEffect:
                {
                    _NsWindow.SetValueForNsobject<NFloat>("setAlphaValue:", new NFloat(options.LuminosityOpacity));
                    _NsWindow.SetValueForNsobject<IntPtr>("setBackgroundColor:", IntPtr.Zero);
                    var contentView = _NsWindow.GetNsobjectFromNsobject("contentView");
                    //if (_PlatformWindow.RootViewController?.View?.BackgroundColor != null)
                    //s_PlatformWindow.RootViewController.View.BackgroundColor = null;

                    var blurEffect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Light);
                    var visualEffectView = new UIVisualEffectView(blurEffect)
                    {
                        TranslatesAutoresizingMaskIntoConstraints = false,
                    };
                    visualEffectView.Frame = _Window.Bounds;

                    _Window.BackgroundColor = UIColor.Clear;
                    _Window.InsertSubview(visualEffectView, 0);
                }
                break;
            default:
                break;
        }
        _NsWindow.SetValueForNsobject<long>("setBackingType:", (long)NSBlacking.NSBackingStoreBuffered);

        return true;
    }

    bool MoveWindow(WindowPresenterKind presenter) => presenter switch
    {
        WindowPresenterKind.Default => MoveWindow(_WindowStartup.WindowAlignment, new(_WindowStartup.Width, _WindowStartup.Height)),
        WindowPresenterKind.Maximize => MoveWindowMaximize(),
        WindowPresenterKind.Minimize => MoveWindowMinimize(),
        WindowPresenterKind.FullScreen => ToggleFullScreen(true),
        _ => false,
    };

    bool MoveWindow(WindowAlignment location, Size size)
    {
        if (_Window is null)
            return false;

        if (_NsWindow is null)
            return false;

        var vScreen = _Window.Screen;
        var vCGRect = vScreen.Bounds;

        var width = size.Width;
        var height = size.Height;

        if (width < 0)
            width = 0;

        if (height < 0)
            height = 0;

        if (width > vCGRect.Width)
            width = vCGRect.Width;

        if (height > vCGRect.Height)
            height = vCGRect.Height;

        var startX = 0d;
        var startY = 0d;
        var realWidth = width * _ScalingFactorX;
        var realHeight = height * _ScalingFactorY;

        switch (location)
        {
            case WindowAlignment.LeftTop:
                break;
            case WindowAlignment.RightTop:
                {
                    startX = vCGRect.Width - realWidth;
                    startY = 0;
                }
                break;
            case WindowAlignment.Center:
                {
                    startX = (vCGRect.Width - realWidth) / 2.0;
                    startY = (vCGRect.Height - realHeight) / 2.0;
                }
                break;
            case WindowAlignment.LeftBottom:
                {
                    startX = 0;
                    startY = vCGRect.Height - realHeight;
                }
                break;
            case WindowAlignment.RightBottom:
                {
                    startX = vCGRect.Width - realWidth;
                    startY = vCGRect.Height - realHeight;
                }
                break;
            default:
                break;
        }
        var cgRect = new CGRect(startX, startY, realWidth, realHeight);

        _NsWindow.SetValueForNsobject<CGRect, bool>("setFrame:display:", cgRect, true);
        _NsWindow.ExecuteMethod("center");

        return true;
    }

    bool MoveWindowMaximize()
    {
        if (_Window is null)
            return false;

        if (_NsWindow is null)
            return false;

        var vScreen = _Window.Screen;
        var vCGRect = vScreen.Bounds;

        double width = vCGRect.Width.Value * _ScalingFactorX;
        double height = vCGRect.Height.Value * _ScalingFactorY;

        var cgRect = new CGRect(0, 0, width, height);
        _NsWindow.SetValueForNsobject<CGRect, bool>("setFrame:display:", cgRect, true);
        _NsWindow.ExecuteMethod("center");

        var rootView = _Window.RootViewController;
        if (rootView is not null)
            rootView.WantsFullScreenLayout = true;

        return true;
    }

    bool MoveWindowMinimize()
    {
        if (_NsWindow is null)
            return false;

        _NsWindow.SetValueForNsobject<IntPtr>("miniaturize:", this.Handle);

        return true;
    }

    bool ToggleFullScreen(bool bFullScreen)
    {
        if (_NsWindow is null)
            return false;

        //var presentOptions = (NSApplicationPresentationOptions)_NsApplication.GetValueFromNsobject<ulong>("currentSystemPresentationOptions");
        //var isFullScreen = presentOptions.HasFlag(NSApplicationPresentationOptions.FullScreen);

        _NsWindow.SetValueForNsobject<IntPtr>("toggleFullScreen:", Handle);
        //var styleMask = (NSWindowStyle)_NsWindow.GetValueFromNsobject<ulong>("styleMask");

        return true;
    }

}
