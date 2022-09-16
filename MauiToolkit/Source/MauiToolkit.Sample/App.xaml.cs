using MauiToolkit.Configurations;
using MauiToolkit.Controls;
using MauiToolkit.Core.Builders;
using MauiToolkit.Core.Extensions;
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
            WindowPresenterKind = WindowPresenterKind.Default,
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
        }.UseWindowChrome(options => 
        {
#if WINDOWS

            options.Icon = FilepathBuilder.Make()
                                          .AddArgument("Resources")
                                          .AddArgument("AppIcon")
                                          .AddArgument("application128.ico")
                                          .Build();

#elif MACCATALYST

                options.Icon = FilepathBuilder.Make()
                                              .AddArgument("Resources")
                                              .AddArgument("app.png")
                                              .Build();
#endif
            options.CaptionHeight = 40;
            options.CaptionActiveBackgroundColor = Colors.Transparent;
            options.WindowTitleBarKind = WindowTitleBarKind.Default;
        });

        return window;
    }
}
