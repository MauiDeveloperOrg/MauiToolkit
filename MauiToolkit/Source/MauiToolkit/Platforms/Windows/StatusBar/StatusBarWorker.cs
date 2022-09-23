using MauiToolkit.Interop;
using MauiToolkit.Interop.Platforms.Windows.Runtimes.Shell32;
using MauiToolkit.Interop.Platforms.Windows.Runtimes.User32;
using Microsoft.Maui.LifecycleEvents;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using static PInvoke.User32;

namespace MauiToolkit.Primitives;
internal partial class StatusBarWorker
{
    readonly uint _WmStatusBarMouseMessage = (uint)NOTIFYMESSAGESINK.NotifyCallBackMessage;
    readonly string _StatusBarCreatedMessage = "StatusBarCreatedMessage";
    int _WmStatusBarCreated;
    string? _StatusBarWindowClassName;
    IntPtr _StatusBarWindowHandle;

    IntPtr m_hMenu = IntPtr.Zero;

    NOTIFYICONDATA _NotifyIconData;
    IntPtr _hIcon = IntPtr.Zero;

    Dictionary<int, MenuItem> _mapMenuItems = new Dictionary<int, MenuItem>();

    partial void ConfigLifeCycle(ILifecycleBuilder builder)
    {
        builder.AddWindows(windowLeftCycle =>
        {
            windowLeftCycle.OnLaunching((app, arg) =>
            {
                RegisterWndClass();


            }).OnClosed((window, arg) =>
            {
                var windows = Application.Current?.Windows;
                if (windows != null)
                {

                }

                OnDisposing();
            });
        });
    }

    partial void MenuItemsChanged(NotifyCollectionChangedEventArgs arg)
    {

    }

    unsafe bool RegisterWndClass()
    {
        _StatusBarWindowClassName = $"StatusBar_Silent_{Guid.NewGuid()}";
        var wndclass = new WNDCLASS
        {
            style = 0,
            lpfnWndProc = WindowProcMessage,
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
            switch ((int)wparam)
            {
                case 1:
                    break;

                default:
                    break;
            }
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
        _NotifyIconData = NOTIFYICONDATA.GetDefaultNotifyData(_StatusBarWindowHandle);
        if (string.IsNullOrWhiteSpace(_Configurations.Icon))
        {
            var processPath = Environment.ProcessPath;
            if (!string.IsNullOrWhiteSpace(processPath))
            {
                var index = IntPtr.Zero;
                hIcon = RuntimeInterop.ExtractAssociatedIcon(IntPtr.Zero, processPath, ref index);
                _NotifyIconData.hIcon = hIcon;
                _NotifyIconData.hBalloonIcon = hIcon;
            }
        }
        else
        {
            hIcon = LoadImage(IntPtr.Zero, _Configurations.Icon, ImageType.IMAGE_ICON, 32, 32, LoadImageFlags.LR_LOADFROMFILE);
            _NotifyIconData.hIcon = hIcon;
            _NotifyIconData.hBalloonIcon = hIcon;
        }

        _hIcon = hIcon;

        if (!string.IsNullOrWhiteSpace(_Configurations.Title))
            _NotifyIconData.szTip = _Configurations.Title;

        return true;
    }

    

    partial void OnDisposing()
    {

    }

}
