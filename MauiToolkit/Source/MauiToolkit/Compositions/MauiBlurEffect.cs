using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiToolkit.Compositions;
public partial class MauiBlurEffect
{
    public static readonly BindableProperty BlurEffectProperty =
                       BindableProperty.CreateAttached("BlurEffect", typeof(MauiBlurEffect), typeof(MauiBlurEffect), default, propertyChanged: OnBlurEffectPropertyChanged);

    public static MauiBlurEffect GetBlurEffect(VisualElement target) => (MauiBlurEffect)target.GetValue(BlurEffectProperty);
    public static void SetBlurEffect(VisualElement target, MauiBlurEffect value) => target.SetValue(BlurEffectProperty, value);

    private static void OnBlurEffectPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        throw new NotImplementedException();
    }
}
