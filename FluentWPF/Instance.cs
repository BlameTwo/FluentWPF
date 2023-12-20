using FluentWPF.Controls;
using FluentWPF.Models.Enums;
using FluentWPF.Win32;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;

namespace FluentWPF;

public static class Instance
{
    public static Application FluentApp { get; private set; }
    public static FluentWindow FluentWin { get; private set; }

    internal static int Theme = 0;
    internal static int SysteBackdrop = 0;

    /// <summary>
    /// 初始化主题，不一定需要这样的注册方式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static void InitTheme<Win,App>(Win win,App app)
        where App :Application
        where Win :FluentWindow
    {
        FluentApp = app;
        FluentWin = win;
    }

    public static void ApplyTheme(ThemeTypeEnum type)
    {
        foreach (var item in FluentApp.Resources.MergedDictionaries)
        {
            if(item is FluentXamlResource resouce)
            {
                resouce.Type = type;
                Theme = (int)type;
                UpdateTheme();
                break;
            }
        }
    }


    internal static void UpdateTheme()
    {
        if (FluentWin == null && FluentApp == null)
            return;
        Methods.DwmSetWindowAttribute(FluentWin.WinHander, (int)DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE, ref Theme, Marshal.SizeOf(typeof(int)));
        Methods.DwmSetWindowAttribute(FluentWin.WinHander, (int)DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, ref SysteBackdrop, Marshal.SizeOf(typeof(int)));
    }
}