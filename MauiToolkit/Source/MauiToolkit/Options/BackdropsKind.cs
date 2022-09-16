namespace MauiToolkit.Options;

public enum BackdropsKind
{
    /// <summary>
    /// default
    /// </summary>
    Default,

//#if WINDOWS
    /// <summary>
    /// Only for winui3
    /// </summary>
    Mica,

    /// <summary>
    /// only for winui3
    /// </summary>
    Acrylic,

//#endif

//#if MACCATALYST || IOS || ANDROID
    /// <summary>
    /// For mac os and ios
    /// </summary>
    BlurEffect

//#endif
}