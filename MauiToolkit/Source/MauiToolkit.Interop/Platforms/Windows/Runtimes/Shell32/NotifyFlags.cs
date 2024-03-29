﻿using static PInvoke.User32;

namespace MauiToolkit.Interop.Platforms.Windows.Runtimes.Shell32;

public enum TimeOutFlags
{
    Minimum_Timeout = 10,
    Maximum_Timeout = 30,
}

public enum NOTIFYICONDATAWFlags
{
    NOTIFYICONDATA_V1_SIZE,
    NOTIFYICONDATA_V2_SIZE,
    NOTIFYICONDATA_V3_SIZE = 952,
}

public enum NOTIFYMESSAGESINK
{
    NotifyCallBackMessage = WindowMessage.WM_USER + 1024,
}

public enum NOTIFYICONVERSIONFlags
{
    NOTIFYICON_VERSION = 0x03,
    NOTIFYICON_VERSION_4 = 0x04,
}