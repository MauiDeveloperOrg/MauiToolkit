using MauiToolkit.Core.Helpers;

namespace MauiToolkit.Sample;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        Loaded += MainPage_Loaded;
        HandlerChanged += MainPage_HandlerChanged;
    }

    private void MainPage_HandlerChanged(object? sender, EventArgs e)
    {

    }

    private void MainPage_Loaded(object? sender, EventArgs e)
    {
        var platform = Handler;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";
        var handlers = ServiceProviderHelper.GetService<IMauiHandlersCollection>();
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

