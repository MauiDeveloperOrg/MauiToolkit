using MauiToolkit.Primitives.WindowStrartup;
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
}
