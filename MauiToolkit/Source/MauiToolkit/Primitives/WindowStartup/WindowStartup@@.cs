using MauiToolkit.Configurations;
using MauiToolkit.Options;
using MauiToolkit.Primitives;
using MauiToolkit.Providers;
using MauiToolkit.Service;

namespace MauiToolkit;
public partial class WindowStartup : IProvider<IWindowStartupService>, IWindowStartupService
{
    WindowStartupWorker? WindowStartupWorker { get; set; }

    public IWindowStartupService? GetService() => this;

    public object? GetService(Type serviceType) => this;

    public T? GetService<T>()
    {
        if (this is T tValue)
            return tValue;

        return default;
    }

    BackdropConfigurations IWindowStartupService.BackdropConfigurations() => BackdropConfigurations;

    bool IWindowStartupService.Maximize()
    {
        WindowPresenterKind = WindowPresenterKind.Maximize;
        return true;
    }

    bool IWindowStartupService.Minimize()
    {
        WindowPresenterKind = WindowPresenterKind.Minimize;
        return true;
    }

    bool IWindowStartupService.ReSize(Size size)
    {
        Width = size.Width;
        Height = size.Height;
        return true;
    }

    bool IWindowStartupService.SwitchBackdrop(BackdropsKind kind)
    {
        BackdropsKind = kind;
        return true;
    }

    bool IWindowStartupService.SwitchFullScreen(bool fullScreen)
    {
        if (fullScreen)
            WindowPresenterKind = WindowPresenterKind.FullScreen;
        else
            WindowPresenterKind = WindowPresenterKind.Default;

        return true;
    }
}
