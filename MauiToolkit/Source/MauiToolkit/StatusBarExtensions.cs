using MauiToolkit.Configurations;
using MauiToolkit.Core.Shared;

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

        return builder;
    }
}
