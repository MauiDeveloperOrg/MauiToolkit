using MauiToolkit.Core.Disposables;
namespace MauiToolkit.Service;

public interface IStatusBarService : ICloseable
{
    public IList<MenuItem> MenuItems { get; }
    bool SwitchIcon(string icon);
    bool SetDescription(string text);
    IDisposable Blink(TimeSpan time, Func<bool, string> callBack);
}
