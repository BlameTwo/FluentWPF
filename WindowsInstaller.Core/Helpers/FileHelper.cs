using System.IO;

namespace WindowsInstaller.Core.Helpers;

public static class FileHelper
{
    /// <summary>
    /// 检查和创建文本文件
    /// </summary>
    /// <param name="path"></param>
    public static void CheckTextFile(string path)
    {
        if (!File.Exists(path))
            File.CreateText(path).Dispose() ;
    }

    /// <summary>
    /// 检查创建文件夹
    /// </summary>
    /// <param name="folder"></param>
    public static void CheckFolder(string folder)
        => Directory.CreateDirectory(folder);
}
