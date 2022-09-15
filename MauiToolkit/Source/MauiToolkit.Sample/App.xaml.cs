using MauiToolkit.Configurations;
using MauiToolkit.Controls;
using MauiToolkit.Core.Shared;
using MauiToolkit.Options;

namespace MauiToolkit.Sample;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        //return base.CreateWindow(activationState);

        if (Windows is not null && Windows.Count > 0)
        {
            var mainWindow = Windows.First();
            mainWindow.Page = MainPage;
            return mainWindow;
        }

        var window = new ClassicalWindow()
        {
            Width = 800d,
            Height = 600d,
            IsShowFllowMouse = true,
            Title = PlatformShared.GetApplicationName(),
            WindowPresenterKind = WindowPresenterKind.FullScreen,
#if MACCATALYST
            BackdropsKind = BackdropsKind.BlurEffect,
            BackdropConfigurations = new BackdropConfigurations
            {
                IsHighContrast = false,
                IsUseBaseKind = true,
                LuminosityOpacity = 1f,
                TintOpacity = 0.5f
            },
#elif WINDOWS
            BackdropsKind = BackdropsKind.Mica,
            BackdropConfigurations = new BackdropConfigurations
            {
                IsHighContrast = false,
                IsUseBaseKind = true,
                LuminosityOpacity = 0.95f,
                TintOpacity = 0.8f,
                //TintColor = Colors.Transparent, 
            },
#endif
            Page = MainPage,
        }.UseWindowChrome();

        return window;
    }
}
