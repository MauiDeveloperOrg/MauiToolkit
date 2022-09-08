using MauiToolkit.Core.Core;

namespace MauiToolkit.Compositions;

public partial class MauiEffect : IAttachedObject
{
    public bool IsAttached { get; protected set; }

    public BindableObject? AssociatedObject { get; protected set; }

    protected VisualElement? _View;

    public void Attach(BindableObject bindableObject)
    {
        if (bindableObject is null)
            return;

        if (bindableObject is not VisualElement view)
            return;

        OnAttaching(view);
        AssociatedObject = bindableObject;
        _View = view;
        view.Loaded += View_Loaded;
        IsAttached = true;
        OnAttached();
    }

    public void Detach()
    {
        var associatedObject = AssociatedObject;
        if (associatedObject is null)
            return;

        var view = _View;
        if (view is null)
            return;

        OnDetaching();
        AssociatedObject = default;
        _View = default;
        view.Loaded -= View_Loaded;
        IsAttached = false;
        OnDetached(view);
    }

    void View_Loaded(object? sender, EventArgs e) => Loaded();

    partial void OnAttaching(VisualElement view);
    partial void OnAttached();
    partial void OnDetaching();
    partial void OnDetached(VisualElement view);
    partial void Loaded();
}
