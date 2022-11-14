namespace MauiToolkit.Extensions;
public static class WindowsExtensions
{
    public static Window Show(this Window window)
    {
        Application.Current?.OpenWindow(window);
        return window;
    }

    public static Window Close(this Window window) 
    {
        Application.Current?.CloseWindow(window);
        return window;
    }
}
