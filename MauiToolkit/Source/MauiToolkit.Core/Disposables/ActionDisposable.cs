namespace MauiToolkit.Core.Disposables;

public class ActionDisposable : IDisposable
{
    public ActionDisposable(Action action)
    {
        _action = action;
    }

    volatile Action? _action;

    public void Dispose()
    {
        Interlocked.Exchange(ref _action, null)?.Invoke();
    }
}
