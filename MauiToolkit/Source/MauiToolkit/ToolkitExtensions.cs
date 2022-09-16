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
        WindowHandlerMapper.AttachMapper();
        return builder;
    }

}
