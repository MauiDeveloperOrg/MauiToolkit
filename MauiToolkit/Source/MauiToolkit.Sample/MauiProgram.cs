namespace MauiToolkit.Sample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiToolkit(options => 
            {
                options.MenuItems.Add(new MenuItem() { Text = "123323" });
                options.MenuItems.Add(new MenuItem() { Text = "456" });
                options.MenuItems.Add(new MenuItem() { Text = "789" });
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
