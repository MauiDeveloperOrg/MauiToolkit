using UIKit;

namespace MauiToolkit.Core.Platforms.MacCatalyst.Extensions;

public static partial class MauixContextExtensions
{
    public static UIWindow GetPlatformWindow(this IMauiContext mauiContext) =>
        mauiContext.Services.GetRequiredService<UIWindow>();
}