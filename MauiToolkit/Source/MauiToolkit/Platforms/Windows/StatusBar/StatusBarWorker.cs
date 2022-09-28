using MauiToolkit.Interop;
using MauiToolkit.Interop.Platforms.Windows.Runtimes.Shell32;
using MauiToolkit.Interop.Platforms.Windows.Runtimes.User32;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using static PInvoke.User32;
using MicrosoftuiXaml = Microsoft.UI.Xaml;

namespace MauiToolkit.Primitives;
internal partial class StatusBarWorker
{
    readonly uint _WmStatusBarMouseMessage = (uint)NOTIFYMESSAGESINK.NotifyCallBackMessage;
    readonly string _StatusBarCreatedMessage = "StatusBarCreatedMessage";

    WndProc? _WndProc;
    int _WmStatusBarCreated;
    string? _StatusBarWindowClassName;
    IntPtr _StatusBarWindowHandle;

    IntPtr m_hMenu = IntPtr.Zero;

    NOTIFYICONDATA _NotifyIconData;
    bool _IsShowIn = false;

    bool _IsLoadedIn = false;
    IntPtr _hIcon = IntPtr.Zero;

    Dictionary<int, MenuItem> _mapMenuItems = new Dictionary<int, MenuItem>();

    partial void ConfigLifeCycle(ILifecycleBuilder builder)
    {
        builder.AddWindows(windowLeftCycle =>
        {
            windowLeftCycle.OnLaunching((app, arg) =>
            {
                RegisterWndClass();
                CreateNotifyIconData();
                CreateMenus();
                ShowStatusBar();
            }).OnClosed((window, arg) =>
            {
                var windows = Application.Current?.Windows;
                if (windows is null || windows.Count <= 1)
                    OnDisposing();
            });
        });
    }

    
    unsafe bool RegisterWndClass()
    {
        _WndProc = WindowProcMessage;
        _StatusBarWindowClassName = $"StatusBar_Silent_{Guid.NewGuid()}";
        var wndclass = new WNDCLASS
        {
            style = 0,
            lpfnWndProc = _WndProc,
            cbClsExtra = 0,
            cbWndExtra = 0,
            hInstance = IntPtr.Zero,
            hIcon = IntPtr.Zero,
            hCursor = IntPtr.Zero,
            hbrBackground = IntPtr.Zero,
            lpszMenuName = null,
            lpszClassName = (char*)(void*)Marshal.StringToCoTaskMemUni(_StatusBarWindowClassName),
        };

        RegisterClass(ref wndclass);
        _WmStatusBarCreated = RegisterWindowMessage(_StatusBarCreatedMessage);
        _StatusBarWindowHandle = CreateWindowEx(0, _StatusBarWindowClassName, "", 0, 0, 0, 1, 1, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

        return true;
    }

    unsafe IntPtr WindowProcMessage(IntPtr hWnd, WindowMessage msg, void* wparam, void* lparam)
    {
        if ((int)msg == _WmStatusBarCreated)
        {

        }
        else if ((int)msg == _WmStatusBarMouseMessage)
        {
            switch ((WindowMessage)((long)lparam))
            {
                case WindowMessage.WM_LBUTTONDOWN:
                    break;
                case WindowMessage.WM_LBUTTONDBLCLK:
                    {
                        var mainWindow = Application.Current?.Windows.FirstOrDefault();
                        if (mainWindow?.Handler?.PlatformView is not MicrosoftuiXaml.Window platformWindow)
                            break;

                        var windowHandle = platformWindow.GetWindowHandle();
                        var isWindowIconic = IsIconic(windowHandle);
                        if (isWindowIconic)
                            PostMessage(windowHandle, WindowMessage.WM_SYSCOMMAND, new IntPtr((int)SysCommands.SC_RESTORE), IntPtr.Zero);
                    }
                    break;
                case WindowMessage.WM_RBUTTONDOWN:
                    {
                        if (m_hMenu == IntPtr.Zero)
                            break;

                        var vPoint = GetCursorPos();
                        RuntimeInterop.TrackPopupMenuEx(m_hMenu, TackMenuFlag.TPM_RIGHTBUTTON, vPoint.x, vPoint.y, _StatusBarWindowHandle, IntPtr.Zero);
                    }
                    break;
                default:
                    break;
            }
        }
        else if (msg == WindowMessage.WM_COMMAND)
        {
            int key = (int)wparam;
            _mapMenuItems.TryGetValue(key, out var menuItem);
            menuItem?.Command?.Execute(menuItem?.CommandParameter);
        }
        else
        {

        }

        return DefWindowProc(hWnd, msg, (IntPtr)wparam, (IntPtr)lparam);
    }

    bool CreateMenus()
    {
        m_hMenu = RuntimeInterop.CreatePopupMenu();
        if (m_hMenu == IntPtr.Zero)
            return false;

        int nCount = GetMenuItemCount(m_hMenu);
        int nIndex = 0;
        foreach (var item in _Configurations.MenuItems)
        {
            int uid = nCount + (++nIndex);
            AppendMenu(m_hMenu, MenuItemFlags.MF_STRING, new IntPtr(uid), item.Text);
            _mapMenuItems[uid] = item;
        }

        return true;
    }

    bool CreateNotifyIconData()
    {
        IntPtr hIcon = IntPtr.Zero;
        var notifyIconData = NOTIFYICONDATA.GetDefaultNotifyData(_StatusBarWindowHandle);
        if (string.IsNullOrWhiteSpace(_Configurations.Icon))
        {
            var processPath = Environment.ProcessPath;
            if (!string.IsNullOrWhiteSpace(processPath))
            {
                var index = IntPtr.Zero;
                hIcon = RuntimeInterop.ExtractAssociatedIcon(IntPtr.Zero, processPath, ref index);
                notifyIconData.hIcon = hIcon;
                notifyIconData.hBalloonIcon = hIcon;
            }
        }
        else
        {
            hIcon = LoadImage(IntPtr.Zero, _Configurations.Icon, ImageType.IMAGE_ICON, 32, 32, LoadImageFlags.LR_LOADFROMFILE);
            notifyIconData.hIcon = hIcon;
            notifyIconData.hBalloonIcon = hIcon;
            _IsLoadedIn = true;
        }

        _hIcon = hIcon;

        if (!string.IsNullOrWhiteSpace(_Configurations.Title))
            notifyIconData.szTip = _Configurations.Title;

        _NotifyIconData = notifyIconData;

        return true;
    }

    bool ShowStatusBar()
    {
        if (Volatile.Read(ref _IsShowIn))
            return true;

        RuntimeInterop.Shell_NotifyIcon(NotifyCommand.NIM_Add, ref _NotifyIconData);
        Volatile.Write(ref _IsShowIn, true);
        return true;
    }

    bool RemoveStatusBar()
    {
        if (!Volatile.Read(ref _IsShowIn))
            return true;

        RuntimeInterop.Shell_NotifyIcon(NotifyCommand.NIM_Delete, ref _NotifyIconData);
        Volatile.Write(ref _IsShowIn, false);
        return true;
    }

    partial void MenuItemsChanged(NotifyCollectionChangedEventArgs arg)
    {

    }

    partial void OnDisposing()
    {
        UnregisterClass(_StatusBarWindowClassName, 0);
        RemoveStatusBar();
        DestroyWindow(_StatusBarWindowHandle);
    }

}
