namespace MauiToolkit.Providers;

public interface IProvider<T> : IProvider
{
    T? GetService();
}
