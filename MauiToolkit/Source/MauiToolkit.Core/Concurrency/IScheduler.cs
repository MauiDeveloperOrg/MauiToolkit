namespace MauiToolkit.Core.Concurrency;
public interface IScheduler
{
    DateTimeOffset Now { get; }

    IDisposable Schedule<TState>(TState state, Action<IScheduler, TState, IDisposable> action);

    IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Action<IScheduler, TState, IDisposable> action);

    IDisposable Schedule<TState>(TState state, DateTimeOffset dueTime, Action<IScheduler, TState, IDisposable> action);
} 
