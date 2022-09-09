using Foundation;
using ObjCRuntime;

namespace MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.Appkit.Notifications;
public static class NsWindow_Notification
{
    public static NSObject ObserveWindowDidBecomeMain(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsWindowDidBecomeMain = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSWindowDidBecomeMainNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(nsWindowDidBecomeMain, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }
}
