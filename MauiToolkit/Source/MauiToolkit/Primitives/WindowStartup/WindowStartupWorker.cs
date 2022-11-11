using MauiToolkit.Core.Core;

namespace MauiToolkit.Primitives;
internal partial class WindowStartupWorker : IAttachedObject
{
    public WindowStartupWorker(WindowStartup windowStartup)
    {
        ArgumentNullException.ThrowIfNull(windowStartup, nameof(windowStartup));
        _WindowStartup = windowStartup;
    }

    readonly WindowStartup _WindowStartup;

    bool _IsAttached = false;

    Window? _AssociatedObject;
    BindableObject? IAttachedObject.AssociatedObject => _AssociatedObject;
    bool IAttachedObject.IsAttached => _IsAttached;

    public void Attach(BindableObject bindableObject)
    {
        if (_IsAttached)
            return;

        if (bindableObject is not Window window)
            return;

        OnAttaching(window);
        _AssociatedObject = window;
        window.Created += Window_Created;
        window.HandlerChanging += Window_HandlerChanging;
        window.HandlerChanged += Window_HandlerChanged;
        window.Deactivated += Window_Deactivated;
        window.Destroying += Window_Destroying;
        window.Stopped += Window_Stopped;
        _WindowStartup.PropertyChanged += WindowStartup_PropertyChanged;
        _IsAttached = true;
        OnAttached();
    }

    public void Detach()
    {
        if (!_IsAttached)
            return;

        var window = _AssociatedObject;
        if (window is null)
            return;

        OnDetaching();
        _AssociatedObject = default;
        window.Created -= Window_Created;
        window.HandlerChanging -= Window_HandlerChanging;
        window.HandlerChanged -= Window_HandlerChanged;
        window.Destroying -= Window_Destroying;
        window.Stopped -= Window_Stopped;
        _WindowStartup.PropertyChanged -= WindowStartup_PropertyChanged;
        _IsAttached = false;
        OnDetached(window);
    }

    private void Window_Created(object? sender, EventArgs e)
    {

    }

    private void Window_HandlerChanging(object? sender, HandlerChangingEventArgs e)
    {
        if (sender is not Window window)
            return;
    }

    private void Window_HandlerChanged(object? sender, EventArgs e) => Loaded();

    private void Window_Destroying(object? sender, EventArgs e) => Destroying();

    private void Window_Deactivated(object? sender, EventArgs e)
    {

    }

    private void Window_Stopped(object? sender, EventArgs e) => Stopped();

    private void WindowStartup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e?.PropertyName))
            return;

        if (_AssociatedObject?.Handler?.PlatformView is null)
            return;

        PropertyChanged(e.PropertyName);
    }

    partial void OnAttaching(Window window);
    partial void OnAttached();
    partial void OnDetaching();
    partial void OnDetached(Window window);
    partial void Loaded();
    partial void Destroying();
    partial void Stopped();
    partial void PropertyChanged(string name);
}
