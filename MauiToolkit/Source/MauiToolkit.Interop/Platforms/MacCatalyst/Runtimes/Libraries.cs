using ObjCRuntime;

namespace MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes;

// All the code in this file is only included on Mac Catalyst.
internal class Libraries
{
    public static class AppKit
    {
        public static readonly IntPtr Handle = Dlfcn.dlopen(Constants.AppKitLibrary, 0);
    }
}
