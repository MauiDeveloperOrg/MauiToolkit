using System.Collections.ObjectModel;

namespace MauiToolkit.Configurations;

public class StatusBarConfigurations
{
    public StatusBarConfigurations()
    {
        MenuItems = new ObservableCollection<MenuItem>();
    }

    /// <summary>
    /// show title default it is the app name
    /// the tookit default value is  AppName
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// show tooltip default ti is the app name 
    /// the tookit default value is  AppName
    /// </summary>
    public string? ToolTipText { get; set; }

    /// <summary>
    /// the icon path 
    /// </summary>
    public string? Icon { get; set; }

    public IList<MenuItem> MenuItems { get; }

}
