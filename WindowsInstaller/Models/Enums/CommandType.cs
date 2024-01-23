using System;

namespace WindowsInstaller.Models.Enums;

public enum CommandType
{
    /// <summary>
    /// 安装
    /// </summary>
    [CommandType(DisplayName ="安装")]
    Install,
    /// <summary>
    /// 卸载
    /// </summary>
    [CommandType(DisplayName = "卸载")]
    Uninstall,
    /// <summary>
    /// 更新升级
    /// </summary>
    [CommandType(DisplayName = "更新")]
    Upgrade
}

[AttributeUsage(AttributeTargets.Field)]
public class CommandTypeAttribute : Attribute
{
    public string DisplayName { get; set; }
}
