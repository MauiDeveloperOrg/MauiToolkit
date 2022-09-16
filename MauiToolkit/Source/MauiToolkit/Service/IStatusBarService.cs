namespace MauiToolkit.Service;

public interface IStatusBarService
{
    bool SwitchIcon(string icon);
    bool SetDescription(string text);
    IDisposable Blink(TimeSpan time, Func<bool, string> callBack);
    bool Close();
}
