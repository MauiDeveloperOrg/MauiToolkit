using ObjCRuntime;

namespace MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.Appkit;
[Flags]
[Native]
public enum NSApplicationPresentationOptions : ulong
{
    Default = 0,
    AutoHideDock = (1 << 0),
    HideDock = (1 << 1),

    AutoHideMenuBar = (1 << 2),
    HideMenuBar = (1 << 3),

    DisableAppleMenu = (1 << 4),
    DisableProcessSwitching = (1 << 5),
    DisableForceQuit = (1 << 6),
    DisableSessionTermination = (1 << 7),
    DisableHideApplication = (1 << 8),
    DisableMenuBarTransparency = (1 << 9),

    FullScreen = (1 << 10),
    AutoHideToolbar = (1 << 11),
    //[Mac(10, 11, 2)]
    DisableCursorLocationAssistance = (1 << 12),
}
