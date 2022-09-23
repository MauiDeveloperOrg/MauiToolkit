using MauiToolkit.Interop.Platforms.Windows.Runtimes.User32;
using static PInvoke.User32;

namespace MauiToolkit.Interop;

// All the code in this file is only included on Windows.
public static partial class RuntimeInterop
{
    private const string _User32 = "user32.dll";

    [DllImport(_User32, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyIcon(IntPtr handle);

    [DllImport(_User32, CharSet = CharSet.Unicode)]
    public static extern IntPtr CreatePopupMenu();

    [DllImport(_User32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool InsertMenuItem(IntPtr hmenu, uint uposition, uint uflags, ref MENUITEMINFO mii);

    [DllImport(_User32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool InsertMenu(IntPtr hmenu, int position, MenuItemFlags uflags, IntPtr uIDNewItemOrSubmenu, string text);

    [DllImport(_User32)]
    public static extern int SetMenuItemBitmaps(IntPtr hmenu, int nPosition, MenuItemFlags uflags, IntPtr hBitmapUnchecked, IntPtr hBitmapChecked);

    [DllImport(_User32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool TrackPopupMenuEx(IntPtr hmenu, TackMenuFlag fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

    [DllImport(_User32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DestroyMenu(IntPtr hmenu);

    [DllImport(_User32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, MenuItemFlags uFlags);

    [DllImport(_User32)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public  static extern bool DrawMenuBar(IntPtr hWnd);
}
