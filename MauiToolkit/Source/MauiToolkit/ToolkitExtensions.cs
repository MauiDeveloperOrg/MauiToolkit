using MauiToolkit.Core;
using MauiToolkit.Interop;
using MauiToolkit.Mappers;

namespace MauiToolkit;

public static class ToolkitxExtensions
{
    public static MauiAppBuilder UseMauiToolkit(this MauiAppBuilder builder)
    {
        return builder.UseMauiToolkitCore()
                      .UseMauiToolkitInterop()
                      .UseHandlerMappers();
    }

    static MauiAppBuilder UseHandlerMappers(this MauiAppBuilder builder)
    {
        new WindowHandlerMapper();
        return builder;
    }


    //public static MauiAppBuilder UseMauiToolkit(this MauiAppBuilder builder, Action<WindowChrome>? configureDelegate)
    //{
    //    return builder;
    //}


}
