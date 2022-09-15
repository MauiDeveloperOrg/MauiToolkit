using MauiToolkit.Primitives;

namespace MauiToolkit;
public partial class WindowStartup
{
    public static readonly BindableProperty WindowStartupProperty =
                       BindableProperty.CreateAttached("WindowStartup", typeof(WindowStartup), typeof(WindowStartup), default, propertyChanged: WindowStartupPropertyChanged);

    public static WindowStartup GetWindowStartup(BindableObject target) => (WindowStartup)target.GetValue(WindowStartupProperty);
    public static void SetWindowStartup(BindableObject target, WindowStartup value) => target.SetValue(WindowStartupProperty, value);

    public static void Remove(Window target)
    {
        target.SetValue(WindowStartupProperty, null);
        target.RemoveBinding(WindowStartup.WindowStartupProperty);
    }

    private static void WindowStartupPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not Window window)
            return;

        if (ReferenceEquals(oldValue, newValue))
            return;

        if (oldValue is WindowStartup oldStartup)
        {
            var windowStartupWorker = oldStartup.WindowStartupWorker;
            oldStartup.WindowStartupWorker = default;
            if (windowStartupWorker is not null)
                windowStartupWorker.Detach();
        }

        if (newValue is WindowStartup windowStartup)
        {
            var windowStartupWorker = new WindowStartupWorker(windowStartup);
            windowStartupWorker.Attach(window);
            windowStartup.WindowStartupWorker = windowStartupWorker;
        }
    }
}

