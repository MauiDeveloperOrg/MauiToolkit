using MauiToolkit.Interop.Platforms.Windows.Runtimes.CoreMessage;
using WindowsSystem = Windows.System;

namespace MauiToolkit.Interop.Platforms.Windows.Primitives;

public sealed class SystemDispatcherQueue
{
    private SystemDispatcherQueue()
    {

    }

    static object __Lock = new();
    static SystemDispatcherQueue? __Instance = default;

    object? _DispatcherQueueController = default;

    public static SystemDispatcherQueue Make()
    {
        lock (__Lock)
            return __Instance ??= new();
    }

    public bool EnsureWindowsSystemDispatcherQueueController()
    {
        if (WindowsSystem.DispatcherQueue.GetForCurrentThread() != null)
            return true;

        if (_DispatcherQueueController == null)
        {
            DispatcherQueueOptions options;
            options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));
            options.threadType = 2;    // DQTYPE_THREAD_CURRENT
            options.apartmentType = 2; // DQTAT_COM_STA

            object? dispatcherQueueController = default;
            RuntimeInterop.CreateDispatcherQueueController(options, ref dispatcherQueueController);
            _DispatcherQueueController = dispatcherQueueController;
        }

        return true;
    }
}
