using MauiToolkit.Primitives;
using MauiToolkit.Providers;
using MauiToolkit.Service;

namespace MauiToolkit;
public partial class WindowChrome : IProvider<IWindowChromeService>, IWindowChromeService
{
    WindowChromeWorker? WindowChromeWorker { get; set; }

    public IWindowChromeService? GetService() => this;

    public object? GetService(Type serviceType) => this;

    public T? GetService<T>()
    {
        if (this is T tValue)
            return tValue;

        return default;
    }
}
