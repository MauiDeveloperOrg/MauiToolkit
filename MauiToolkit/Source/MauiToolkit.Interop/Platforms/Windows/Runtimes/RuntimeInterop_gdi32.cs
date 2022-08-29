namespace MauiToolkit.Interop;

// All the code in this file is only included on Windows.
public static partial class RuntimeInterop
{
    private const string _Gdi32 = "gdi32.dll";

    [DllImport(_Gdi32, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject(IntPtr hObject);
}
