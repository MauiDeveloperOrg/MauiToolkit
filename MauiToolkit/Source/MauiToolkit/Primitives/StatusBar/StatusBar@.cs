﻿using MauiToolkit.Configurations;
using MauiToolkit.Service;

namespace MauiToolkit;
internal partial class StatusBar : IStatusBarService
{
    public IDisposable Blink(TimeSpan time, Func<bool, string> callBack)
    {
        throw new NotImplementedException();
    }

    public bool Close()
    {
        throw new NotImplementedException();
    }

    public bool SetDescription(string text)
    {
        throw new NotImplementedException();
    }

    public bool SwitchIcon(string icon)
    {
        throw new NotImplementedException();
    }
}
