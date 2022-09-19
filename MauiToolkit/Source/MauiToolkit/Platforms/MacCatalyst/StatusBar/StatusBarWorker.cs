using Microsoft.Maui.LifecycleEvents;

namespace MauiToolkit.Primitives;
internal partial class StatusBarWorker
{
    partial void ConfigLifeCycle(ILifecycleBuilder builder)
    {
        builder.AddiOS(iOSLifecycle =>
        {
            iOSLifecycle.FinishedLaunching((app, options) => 
            { 
                return true;
            });
        });
    }
}
