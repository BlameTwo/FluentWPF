using System.Runtime.InteropServices;

namespace NeteaseCloudApp.Helpers;

public static class ShellHelper
{
    [DllImport("shell32.dll")] // 声明外部函数
    static extern IntPtr ShellExecute(
        IntPtr hwnd, // 父窗口句柄，可以为IntPtr.Zero
        string lpOperation, // 操作名称，可以为"open"或"explore"
        string lpFile, // 文件名称，可以是相对路径或绝对路径
        string lpParameters, // 参数，可以为null
        string lpDirectory, // 工作目录，可以为null
        int nShowCmd // 显示方式，可以为SW_SHOWNORMAL等常量
    );

    public enum ShowWindowCommand
    {
        SW_HIDE = 0, // 隐藏窗口
        SW_SHOWNORMAL = 1, // 正常显示窗口
        SW_SHOWMINIMIZED = 2, // 最小化显示窗口
        SW_SHOWMAXIMIZED = 3, // 最大化显示窗口
        SW_MAXIMIZE = 3, // 最大化窗口
        SW_SHOWNOACTIVATE = 4, // 不激活显示窗口
        SW_SHOW = 5, // 激活显示窗口
        SW_MINIMIZE = 6, // 最小化窗口
        SW_SHOWMINNOACTIVE = 7, // 不激活最小化显示窗口
        SW_SHOWNA = 8, // 不激活显示窗口
        SW_RESTORE = 9, // 恢复窗口
        SW_SHOWDEFAULT = 10 // 默认显示窗口
    }

    /// <summary>
    /// 显示一个文件
    /// </summary>
    /// <param name="action"></param>
    /// <param name="Filepath"></param>
    /// <param name="workdirectory"></param>
    /// <param name="Type"></param>
    /// <returns></returns>
    public static IntPtr OpenExplorerFile(string action,string Filepath,string workdirectory, ShowWindowCommand Type)
    {
        return  ShellExecute(IntPtr.Zero, action, Filepath, null, workdirectory, (int)Type);
    }
}
