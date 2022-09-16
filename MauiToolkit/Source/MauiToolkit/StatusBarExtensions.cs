using MauiToolkit.Configurations;
using MauiToolkit.Core.Shared;
using MauiToolkit.Service;
using Microsoft.Extensions.DependencyInjection;

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
        var statusBar = new StatusBar(options);
        builder.Services.AddSingleton<IStatusBarService>(statusBar);

        return builder;
    }
}
