﻿using FluentWPF.Models.Enums;
using System.Runtime.InteropServices;

namespace FluentWPF.Common;

public abstract class SystemBackdropBase
{
    public SystemBackdropBase(SystemBackdropTypeEnum systemBackdropTypeEnum)
    {
        SystemBackdropTypeEnum = systemBackdropTypeEnum;
    }

    public SystemBackdropTypeEnum SystemBackdropTypeEnum { get; }

    public virtual void ChangedBackdrop()
    {
        Instance.InstanceLogOutputHandler?.Invoke(this, new Models.UILogModel(LogType.INFO, "更换系统笔刷"));
    }

    public void SetBackdrop()
    {
        int drop = (int)SystemBackdropTypeEnum;
        Instance.SysteBackdrop = drop;
        Instance.UpdateTheme();
        ChangedBackdrop();
    }
}
