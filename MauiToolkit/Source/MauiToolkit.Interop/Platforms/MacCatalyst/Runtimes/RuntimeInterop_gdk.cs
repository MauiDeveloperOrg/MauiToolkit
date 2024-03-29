﻿namespace MauiToolkit.Interop;

// All the code in this file is only included on Mac Catalyst.
public static partial class RuntimeInterop
{
    private const string _OSXLibGdkName = "libgdk-quartz-2.0.0.dylib";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    [SuppressUnmanagedCodeSecurity, DllImport(_OSXLibGdkName)]
    public static extern IntPtr gdk_quartz_window_get_nswindow(IntPtr handle);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    [SuppressUnmanagedCodeSecurity, DllImport(_OSXLibGdkName)]
    public static extern IntPtr gdk_quartz_window_get_nsview(IntPtr handle);
}
