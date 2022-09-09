using Foundation;
using ObjCRuntime;

namespace MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.Appkit.Notifications;
public static class NsApplication_Notifications
{
    public static NSObject NSApplicationWillFinishLaunching(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationWillFinishLaunching = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationWillFinishLaunchingNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationWillFinishLaunching, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationDidFinishLaunching(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationDidFinishLaunching = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationDidFinishLaunchingNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationDidFinishLaunching, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationWillBecomeActive(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var naApplicationWillBecomeActive = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationWillBecomeActiveNotification");

        return NSNotificationCenter.DefaultCenter.AddObserver(naApplicationWillBecomeActive, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }
    public static NSObject NSApplicationDidBecomeActive(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationDidBecomeActive = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationDidBecomeActiveNotification");

        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationDidBecomeActive, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationWillResignActive(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationWillResignActive = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationWillResignActiveNotification");

        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationWillResignActive, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationDidResignActive(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationDidResignActive = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationDidResignActiveNotification");

        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationDidResignActive, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationDidChangeOcclusionState(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationDidResignActive = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationDidResignActiveNotification");

        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationDidResignActive, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationDidChangeScreenParameters(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationDidChangeScreenParameters = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationDidChangeScreenParametersNotification");

        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationDidChangeScreenParameters, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject NSApplicationDidFinishRestoringWindows(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationDidFinishRestoringWindows = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSApplicationDidFinishRestoringWindowsNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationDidFinishRestoringWindows, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }
    
    public static NSObject NsApplicationActivated(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationActived = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSAccessibilityApplicationActivatedNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationActived, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject WindowCreated(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var naApplicationWindowCreated = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSAccessibilityWindowCreatedNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(naApplicationWindowCreated, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

    public static NSObject MainWindowChanged(EventHandler<NSNotificationEventArgs> handler)
    {
        EventHandler<NSNotificationEventArgs> handler2 = handler;
        var nsApplicationMainWindowChanged = Dlfcn.GetStringConstant(Libraries.AppKit.Handle, "NSAccessibilityMainWindowChangedNotification");
        return NSNotificationCenter.DefaultCenter.AddObserver(nsApplicationMainWindowChanged, delegate (NSNotification notification)
        {
            handler2(null, new NSNotificationEventArgs(notification));
        });
    }

   

   
}