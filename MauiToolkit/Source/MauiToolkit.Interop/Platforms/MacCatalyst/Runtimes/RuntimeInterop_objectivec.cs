using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using MapKit;
using MauiToolkit.Interop.Platforms.MacCatalyst.Runtimes.ObjC;
using ObjCRuntime;

namespace MauiToolkit.Interop;

// All the code in this file is only included on Mac Catalyst.
public static partial class RuntimeInterop
{
    private const string _ObjectiveCLibrary = Constants.ObjectiveCLibrary;

    #region  void_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_bool(IntPtr receiver, IntPtr selector, bool value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int(IntPtr receiver, IntPtr selector, int value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_long(IntPtr receiver, IntPtr selector, long value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_nFloat(IntPtr receiver, IntPtr selector, NFloat value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_CGSize(IntPtr receiver, IntPtr selector, CGSize value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_CGRect(IntPtr receiver, IntPtr selector, CGRect value);


    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value);

    public static void void_objc_msgSend_string(IntPtr receiver, IntPtr selector, string value)
    {
        var ptr = CFString.CreateNative(value);
        void_objc_msgSend_IntPtr(receiver, selector, ptr);
        CFString.ReleaseNative(ptr);
    }

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_ref_IntPtr(IntPtr receiver, IntPtr selector, ref IntPtr value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_out_IntPtr(IntPtr receiver, IntPtr selector, out IntPtr value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1, IntPtr value2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_CGRect_bool(IntPtr receiver, IntPtr selector, CGRect value1, bool value2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int_ref_int_outint(IntPtr receiver, IntPtr selector, int p1, ref int p2, out int p3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, int p1, IntPtr p2, IntPtr p3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int_ref_IntPtr_out_IntPtr(IntPtr receiver, IntPtr selector, int p1, ref IntPtr p2, out IntPtr p3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr_bool(IntPtr receiver, IntPtr selector, IntPtr value1, IntPtr value2, bool value3);

#if NET

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int_Handle_Handle(IntPtr receiver, IntPtr selector, int p1, ref NativeHandle p2, out NativeHandle p3);

#endif

    public static void void_objc_msgSend_IntPtr_string_bool(IntPtr receiver, IntPtr selector, IntPtr value1, string value2, bool value3)
    {
        var ptr = CFString.CreateNative(value2);
        void_objc_msgSend_IntPtr_IntPtr_bool(receiver, selector, value1, ptr, value3);
        CFString.ReleaseNative(ptr);
    }

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int_int_long(IntPtr receiver, IntPtr selector, int value1, int value2, long value3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_long_int_long(IntPtr receiver, IntPtr selector, long value1, int value2, long value3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_ref_BlockLiteral(IntPtr receiver, IntPtr selector, IntPtr value1, ref BlockLiteral value2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr_ref_BlockLiteral(IntPtr receiver, IntPtr selector, IntPtr p1, IntPtr p2, ref BlockLiteral p3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1, IntPtr value2, IntPtr value3, IntPtr value4);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_CGPoint_ref_CGPoint(IntPtr receiver, IntPtr selector, IntPtr scrollView, CGPoint velocity, ref CGPoint targetContentOffset);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_NSRange_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1, IntPtr value2, IntPtr value3, NSRange value4, IntPtr value5);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_long_int_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1, IntPtr value2, IntPtr value3, long value4, int value5, IntPtr value6);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_int_int_int_int_int_int_IntPtr(IntPtr receiver, IntPtr selector, int value1, int value2, int value3, int value4, int value5, int value6, IntPtr value7);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static void void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, ref IntPtr p1, ref IntPtr p2, ref IntPtr p3, ref IntPtr p4, ref IntPtr p5, ref IntPtr p6, ref IntPtr p7);

    #endregion

    #region void_objc_msg_super

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSendSuper")]
    public extern static void void_objc_msgSendSuper(ref objc_super receiver, IntPtr selector);

    #endregion

    #region bool_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    [return: MarshalAs(UnmanagedType.I1)]
    public extern static bool bool_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    [return: MarshalAs(UnmanagedType.I1)]
    public extern static bool bool_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    [return: MarshalAs(UnmanagedType.I1)]
    public extern static bool bool_objc_msgSend_IntPtr_int(IntPtr receiver, IntPtr selector, IntPtr value1, int value2);

    #endregion

    #region int_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static int int_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static int int_objc_msgSend_int(IntPtr receiver, IntPtr selector, int value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static int int_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1);

    #endregion

    #region nint_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static nint nint_objc_msgSend_IntPtr_nint(IntPtr receiver, IntPtr selector, IntPtr value1, nint value2);

    #endregion

    #region long_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static long long_objc_msgSend(IntPtr receiver, IntPtr selector);

    #endregion

    #region float_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static float float_objc_msgSend(IntPtr receiver, IntPtr selector);

    #endregion

    #region double_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static double double_objc_msgSend(IntPtr receiver, IntPtr selector);

    #endregion

    #region CG_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGPoint CGPoint_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGSize CGSize_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_int(IntPtr receiver, IntPtr selector, int value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_CGRect(IntPtr receiver, IntPtr selector, CGRect p1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_CGRect_int(IntPtr receiver, IntPtr selector, CGRect p1, int p2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_CGRect_CGRect_float(IntPtr receiver, IntPtr selector, CGRect p1, CGRect p2, float p3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_CGRect_CGRect_CGRect(IntPtr receiver, IntPtr selector, CGRect p1, CGRect p2, CGRect p3);

#if !__TVOS__

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_MKMapRect(IntPtr receiver, IntPtr selector, MKMapRect p1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CGRect CGRect_objc_msgSend_MKCoordinateRegion_IntPtr(IntPtr receiver, IntPtr selector, MKCoordinateRegion p1, IntPtr p2);

#endif // !__TVOS__

#if !__WATCHOS__
#if !NET

    [DllImport (_ObjectiveCLibrary, EntryPoint="objc_msgSend")]
	public extern static Matrix3 Matrix3_objc_msgSend (IntPtr receiver, IntPtr selector);

#endif // !NET

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static CATransform3D CATransform3D_objc_msgSend(IntPtr receiver, IntPtr selector);

#endif // !__WATCHOS__

    #endregion

    #region intptr_objc_msg

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_bool(IntPtr receiver, IntPtr selector, [MarshalAs(UnmanagedType.I1)] bool value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_int(IntPtr receiver, IntPtr selector, int value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_long(IntPtr receiver, IntPtr selector, long value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public static extern IntPtr IntPtr_objc_msgSend_nfloat(IntPtr receiver, IntPtr selector, NFloat value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_CGSize(IntPtr receiver, IntPtr selector, CGSize value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1);

    public static IntPtr IntPtr_objc_msgSend_string(IntPtr receiver, IntPtr selector, string value)
    {
        var ptr = CFString.CreateNative(value);
        var intPtr = IntPtr_objc_msgSend_IntPtr(receiver, selector, ptr);
        CFString.ReleaseNative(ptr);

        return intPtr;
    }

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_double_double(IntPtr receiver, IntPtr selector, double a, double b);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_ref_IntPtr(IntPtr receiver, IntPtr selector, ref IntPtr value1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr value1, IntPtr value2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr actionSelector, IntPtr value1, IntPtr value2);




    #endregion


    #region void_objc_msg_stret


    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGPoint_objc_msgSend_stret(out CGPoint buf, IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGSize_objc_msgSend_stret(out CGSize buf, IntPtr receiver, IntPtr selector);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_int(out CGRect buf, IntPtr receiver, IntPtr selector, int p1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_IntPtr(out CGRect buf, IntPtr receiver, IntPtr selector, IntPtr p1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_CGRect(out CGRect buf, IntPtr receiver, IntPtr selector, CGRect p1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_CGRect_int(out CGRect buf, IntPtr receiver, IntPtr selector, CGRect p1, int p2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_CGRect_IntPtr(out CGRect buf, IntPtr receiver, IntPtr selector, CGRect p1, IntPtr p2);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_CGRect_CGRect_float(out CGRect buf, IntPtr receiver, IntPtr selector, CGRect p1, CGRect p2, float p3);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_CGRect_CGRect_CGRect(out CGRect buf, IntPtr receiver, IntPtr selector, CGRect p1, CGRect p2, CGRect p3);


#if !__WATCHOS__

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CATransform3D_objc_msgSend_stret(out CATransform3D buf, IntPtr receiver, IntPtr selector);
#endif // !__WATCHOS__

#if !__TVOS__

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_MKMapRect(out CGRect buf, IntPtr receiver, IntPtr selector, MKMapRect p1);

    [DllImport(_ObjectiveCLibrary, EntryPoint = "objc_msgSend_stret")]
    public extern static void CGRect_objc_msgSend_stret_MKCoordinateRegion_IntPtr(out CGRect buf, IntPtr receiver, IntPtr selector, MKCoordinateRegion p1, IntPtr p2);

#endif // !__TVOS__

#if !__WATCHOS__ && !NET
		[DllImport (_ObjectiveCLibrary, EntryPoint="objc_msgSend_stret")]
		public extern static void Matrix3_objc_msgSend_stret (out Matrix3 buf, IntPtr receiver, IntPtr selector);
#endif // !__WATCHOS__ && !NET


    #endregion


}
