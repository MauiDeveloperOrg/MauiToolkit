using MauiToolkit.Configurations;
using MauiToolkit.Options;

namespace MauiToolkit.Service;
public interface IWindowStartupService 
{
    bool ReSize(Size size);
    bool SwitchFullScreen(bool fullScreen);
    bool SwitchBackdrop(BackdropsKind kind);
    BackdropConfigurations BackdropConfigurations();
    bool Maximize();
    bool Minimize();

}
