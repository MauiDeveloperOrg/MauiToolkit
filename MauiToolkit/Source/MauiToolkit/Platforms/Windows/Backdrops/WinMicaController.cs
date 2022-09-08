using MauiToolkit.Interop.Platforms.Windows.Primitives;

namespace MauiToolkit.Platforms.Windows.Backdrops;
internal class WinMicaController : IDisposable
{
    public WinMicaController()
    {
        var maker = SystemDispatcherQueue.Make();
        maker.EnsureWindowsSystemDispatcherQueueController();
    }

    public void Dispose()
    {
        
    }
}
