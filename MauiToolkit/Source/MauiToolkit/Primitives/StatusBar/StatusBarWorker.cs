using MauiToolkit.Configurations;
using Microsoft.Maui.LifecycleEvents;

namespace MauiToolkit.Primitives;
internal partial class StatusBarWorker
{
    public StatusBarWorker(StatusBarConfigurations config)
    {
        _Configurations = config;
    }

    readonly StatusBarConfigurations _Configurations;

    internal void RegisterApplicationLifeCycle(ILifecycleBuilder builder) => ConfigLifeCycle(builder);

    partial void ConfigLifeCycle(ILifecycleBuilder builder);
}
