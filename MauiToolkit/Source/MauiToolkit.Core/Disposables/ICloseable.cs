namespace MauiToolkit.Core.Disposables;
public interface ICloseable : IDisposable
{
    bool Close();
}