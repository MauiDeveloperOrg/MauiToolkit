namespace MauiToolkit.Core.Concurrency;
public static class SchedulerFactory
{
    public static IDisposable Schedule<TState>(TState state, Action<IScheduler, TState, IDisposable> action)
    {
        throw new NotImplementedException();
    }

}
