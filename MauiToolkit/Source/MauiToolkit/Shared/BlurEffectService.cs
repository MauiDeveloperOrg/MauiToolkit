using MauiToolkit.Compositions;
using MauiToolkit.Service;

namespace MauiToolkit.Shared;

internal partial class BlurEffectService : IService
{
    public BlurEffectService(VisualElement visual, MauiEffect effect)
    {
        _Visual = visual;
        _Effect = effect;
    }

    readonly VisualElement _Visual;
    readonly MauiEffect _Effect;

    bool _IsRuned = false;
    bool _IsLoaded = false;

    public bool Run()
    {
        if (_IsRuned)
            return true;

        _Visual.Loaded += Visual_Loaded;
        _Visual.Unloaded += Visual_Unloaded;
        _IsRuned = true;
        return true;
    }

    public bool Stop()
    {
        if (!_IsRuned)
            return true;

        _Visual.Loaded -= Visual_Loaded;
        _Visual.Unloaded -= Visual_Unloaded;
        _IsRuned = false;
        return true;
    }

    private void Visual_Loaded(object? sender, EventArgs e)
    {
        if (_IsLoaded)
            return;

        OnLoaded();
        _IsLoaded = true;
    }

    private void Visual_Unloaded(object? sender, EventArgs e)
    {
        if (!_IsLoaded)
            return;

        UnLoaded();
        _IsLoaded = false;
    }


#if !WINDOWS && !MACCATALYST
    void OnLoaded() { }
    void UnLoaded() { }
#endif
}
