﻿using MauiToolkit.Core.Platforms.Windows.Extensions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using PlatformControls = Microsoft.UI.Xaml.Controls;
using PlatformSharps = Microsoft.UI.Xaml.Shapes;

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
        _PlatformAcrylicBrush = default;
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
        {
            shape.Fill = _PlatformAcrylicBrush;
            shape.RegisterPropertyChangedCallback(PlatformSharps.Shape.FillProperty, OnDependencyPropertyChanged);
        }
        else if (platformView is PlatformControls.Panel panel)
        {
            panel.Background = _PlatformAcrylicBrush;
            panel.RegisterPropertyChangedCallback(PlatformControls.Panel.BackgroundProperty, OnDependencyPropertyChanged);
        }
        else if (platformView is PlatformControls.Control control)
        {
            control.Background = _PlatformAcrylicBrush;
            control.RegisterPropertyChangedCallback(PlatformControls.Control.BackgroundProperty, OnDependencyPropertyChanged);
        }
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

    void OnDependencyPropertyChanged(DependencyObject sender, DependencyProperty dp)
    {
        if (_View?.Handler?.PlatformView is null)
            return;

        var platformView = _View.Handler.PlatformView;

        if (platformView is PlatformSharps.Shape shape)
        {
            if (dp != PlatformSharps.Shape.FillProperty)
                return;

            if (shape.Fill is null)
                shape.Fill = _PlatformAcrylicBrush;
        }
        else if (platformView is PlatformControls.Panel panel)
        {
            if (dp != PlatformControls.Panel.BackgroundProperty)
                return;

            if (panel.Background is null)
                panel.Background = _PlatformAcrylicBrush;
        }
        else if (platformView is PlatformControls.Control control)
        {
            if (dp != PlatformControls.Control.BackgroundProperty)
                return;

            if (control.Background is null)
                control.Background = _PlatformAcrylicBrush;
        }
    }

}
