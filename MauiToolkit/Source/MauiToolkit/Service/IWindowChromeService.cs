using MauiToolkit.Options;

namespace MauiToolkit.Service;

public interface IWindowChromeService
{
    bool SetCaptionHeight(double height);
    bool SwitchTitleBar(WindowTitleBarKind kind);
    bool SetButtonKind(WindowButtonKind kind);
}
