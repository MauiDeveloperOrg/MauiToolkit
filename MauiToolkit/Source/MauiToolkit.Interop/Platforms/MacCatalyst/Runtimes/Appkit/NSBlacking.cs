using ObjCRuntime;

namespace MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.Appkit;

[Flags]
[Native]
public enum NSBlacking
{
    NSBackingStoreRetained = 0, //compatible old 
    NSBackingStoreNonretained = 1, //no cache
    NSBackingStoreBuffered = 2  //draw cache
}