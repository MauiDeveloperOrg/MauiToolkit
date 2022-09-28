namespace MauiToolkit.Assists;

public static class ElementAssist
{
    public static readonly BindableProperty TagProperty =
                      BindableProperty.CreateAttached("Tag", typeof(object), typeof(ElementAssist), default);

    public static object GetTag(Element target) => (object)target.GetValue(TagProperty);
    public static void SetTag(Element target, object value) => target.SetValue(TagProperty, value);

}
