using MauiToolkit.Primitives;

namespace MauiToolkit;
public partial class WindowChrome
{
    public static readonly BindableProperty WindowChromeProperty =
                       BindableProperty.CreateAttached("WindowChrome", typeof(WindowChrome), typeof(WindowChrome), default, propertyChanged: WindowChromePropertyChanged);

    public static WindowChrome GetWindowChrome(BindableObject target) => (WindowChrome)target.GetValue(WindowChromeProperty);
    public static void SetWindowChrome(BindableObject target, WindowChrome value) => target.SetValue(WindowChromeProperty, value);

    public static readonly BindableProperty IsViewCanHitProperty =
                   BindableProperty.CreateAttached("IsViewCanHit", typeof(WindowChrome), typeof(WindowChrome), default, propertyChanged: IsViewCanHitPropertyChanged);

    public static WindowChrome GetIsViewCanHit(BindableObject target) => (WindowChrome)target.GetValue(IsViewCanHitProperty);
    public static void SetIsViewCanHit(BindableObject target, WindowChrome value) => target.SetValue(IsViewCanHitProperty, value);


    public static void Remove(Window target)
    {
        target.SetValue(WindowChromeProperty, null);
        target.RemoveBinding(WindowChrome.WindowChromeProperty);
    }

    private static void WindowChromePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not Window window)
            return;

        if (ReferenceEquals(oldValue, newValue))
            return;

        if (oldValue  is WindowChrome oldChrome)
        {
            var windowChromeWorker = oldChrome.WindowChromeWorker;
            oldChrome.WindowChromeWorker = default;
            if (windowChromeWorker is not null)
                windowChromeWorker.Detach();
        }

        if (newValue is WindowChrome windowChrome)
        {
            var windowChromeWorker = new WindowChromeWorker(windowChrome);
            windowChromeWorker.Attach(window);
            windowChrome.WindowChromeWorker = windowChromeWorker;
        }

    }

    private static void IsViewCanHitPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
         
    }

}
