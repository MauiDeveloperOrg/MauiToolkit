using MauiToolkit.Core.Builders;

namespace MauiToolkit.Core.Shared;

public class PlatformShared
{
    public static string GetApplicationName()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        var appName = entryAssembly?.GetName().Name;
        if (!string.IsNullOrWhiteSpace(appName))
            return appName;

        appName = Application.Current?.Windows?.FirstOrDefault()?.Title;
        if (!string.IsNullOrWhiteSpace(appName))
            return appName;

        //this is null when in ios
#if WINDOWS || MACCATALYST 
        appName = Process.GetCurrentProcess().ProcessName;
#else
        appName = "Application";
#endif

        return appName;
    }

    public static FilepathBuilder CreatePathBuilder()
    {
        var builder = new FilepathBuilder();
        builder.SetBasicDirectory();
        return builder;
    }

}
