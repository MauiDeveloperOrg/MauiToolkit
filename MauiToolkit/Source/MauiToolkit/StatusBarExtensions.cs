using MauiToolkit.Configurations;
using MauiToolkit.Core;
using MauiToolkit.Core.Shared;
using MauiToolkit.Primitives;
using MauiToolkit.Service;
using Microsoft.Maui.LifecycleEvents;

namespace MauiToolkit;
public static class StatusBarExtensions
{
    public static MauiAppBuilder UseStatusBar(this MauiAppBuilder builder) => builder.UseStatusBar(default);

    public static MauiAppBuilder UseStatusBar(this MauiAppBuilder builder, Action<StatusBarConfigurations>? configureDelegate)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        var appName = PlatformShared.GetApplicationName();
        var options = new StatusBarConfigurations()
        {
            Title = appName,
            ToolTipText = appName,
        };
        configureDelegate?.Invoke(options);
        var statusBar = new StatusBarWorker(options);
        builder.Services.AddSingleton<IStatusBarService>(statusBar);
        builder.ConfigureLifecycleEvents(lefecycle => statusBar.RegisterApplicationLifeCycle(lefecycle));

        return builder;
    }
}
