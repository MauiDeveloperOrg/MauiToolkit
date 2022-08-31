namespace MauiToolkit.Providers;

public interface IProvider
{
    object? GetService(Type serviceType);

    T? GetService<T>();
}
