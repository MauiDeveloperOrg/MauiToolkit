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

        var theme = Application.Current?.RequestedTheme; 
        var window = new ClassicalWindow()
        {
            Width = 1200d,
            Height = 900d,
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
                LuminosityOpacity = theme == AppTheme.Dark ? 0.5f : 0.9f,
                TintOpacity = theme == AppTheme.Dark ? 0.3f : 0.75f,
                TintColor = theme == AppTheme.Dark ? Colors.Black : Colors.Transparent, 
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
            options.WindowTitleBarKind = WindowTitleBarKind.CustomTitleBarAndExtension;
            options.WindowButtonKind = WindowButtonKind.Hide;
        });

        return window;
    }
}
