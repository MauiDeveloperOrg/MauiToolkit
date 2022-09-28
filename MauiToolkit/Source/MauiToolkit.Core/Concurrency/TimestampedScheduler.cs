using MauiToolkit.Core.Disposables;

namespace MauiToolkit.Core.Concurrency;
internal class TimestampedScheduler: ICancelable, IScheduler
{
    public TimestampedScheduler()
    {

    }

    ~TimestampedScheduler()
    {
        Dispose(disposing: false);
    }

    private bool disposedValue;

    //private Action<IScheduler, TState, IDisposable> 
    bool ICancelable.IsDisposed => disposedValue;

    DateTimeOffset IScheduler.Now => DateTimeOffset.Now;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }

            disposedValue = true;
        }
    }

    void IDisposable.Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    IDisposable IScheduler.Schedule<TState>(TState state, Action<IScheduler, TState, IDisposable> action)
    {
        throw new NotImplementedException();
    }

    IDisposable IScheduler.Schedule<TState>(TState state, TimeSpan dueTime, Action<IScheduler, TState, IDisposable> action)
    {
        throw new NotImplementedException();
    }

    IDisposable IScheduler.Schedule<TState>(TState state, DateTimeOffset dueTime, Action<IScheduler, TState, IDisposable> action)
    {
        throw new NotImplementedException();
    }
}
