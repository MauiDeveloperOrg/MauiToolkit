using MauiToolkit.Core.Helpers;

namespace MauiToolkit.Compositions;

public partial class MauiEffect
{
    public static readonly BindableProperty BlurEffectProperty =
                       BindableProperty.CreateAttached("BlurEffect", typeof(MauiEffect), typeof(MauiEffect), default, propertyChanged: OnBlurEffectPropertyChanged);

    public static MauiEffect GetBlurEffect(VisualElement target) => (MauiEffect)target.GetValue(BlurEffectProperty);
    public static void SetBlurEffect(VisualElement target, MauiEffect value) => target.SetValue(BlurEffectProperty, value);

    private static void OnBlurEffectPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not VisualElement visual)
            return;

 


    }

    
}
