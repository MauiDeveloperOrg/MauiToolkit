using MauiToolkit.Core.Disposables;
using MauiToolkit.Service;

namespace MauiToolkit.Primitives;
internal partial class StatusBarWorker : IStatusBarService
{
    public IList<MenuItem> MenuItems => _Configurations.MenuItems;

    public IDisposable Blink(TimeSpan time, Func<bool, string> callBack)
    {
        throw new NotImplementedException();
    }

    bool IStatusBarService.SetDescription(string text)
    {
        throw new NotImplementedException();
    }

    bool IStatusBarService.SwitchIcon(string icon)
    {
        throw new NotImplementedException();
    }

    bool ICloseable.Close()
    {
        ((IDisposable)this).Dispose();
        return true;
    }

    void IDisposable.Dispose() => OnDisposing();

}
