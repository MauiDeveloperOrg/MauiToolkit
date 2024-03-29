﻿namespace MauiToolkit.Options;

public enum WindowTitleBarKind
{
    /// <summary>
    /// Maui default
    /// </summary>
    Default,

    /// <summary>
    /// plateform default WinUI3 default is not same with Maui default
    /// </summary>
    PlatformDefault,

    /// <summary>
    /// 
    /// </summary>
    DefaultWithExtension,

    /// <summary>
    /// remove titlebar
    /// </summary>
    CustomTitleBarAndExtension,
}