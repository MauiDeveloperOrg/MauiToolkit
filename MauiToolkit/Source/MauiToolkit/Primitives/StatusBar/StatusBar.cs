using MauiToolkit.Configurations;

namespace MauiToolkit;
internal partial class StatusBar
{
    public StatusBar(StatusBarConfigurations config)
    {
        _Configurations = config;
    }

    readonly StatusBarConfigurations _Configurations;
}
