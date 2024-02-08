using FluentWPF.Controls;
using JsonToolkit;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Interop;
using ToolkitBase;
using System;
using System.IO;
using System.Text;
using ToolkitBox.ViewModels;
namespace ToolkitBox;

public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
        this.Deactivated += MainWindow_Deactivated;
    }

    private void MainWindow_Deactivated(object? sender, EventArgs e)
    {
        this.Hide();
    }

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
    static extern nint GetWindowLongPtr(nint hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    static extern nint SetWindowLongPtr(nint hWnd, int nIndex, IntPtr dwNewLong);

    const int GWL_STYLE = -16;
    const int WS_CAPTION = 0x00C00000;
    const int WS_SYSMENU = 0x00080000;
    const int WS_THICKFRAME = 0x00040000;

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    const uint MOD_CONTROL = 0x0002;
    const uint MOD_ALT = 0x0001;
    const uint VK_SPACE = 0x20;
    const int WM_HOTKEY = 0x0312;
    const int HOTKEY_ID = 9000;


    private async void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        var windowHelper = new WindowInteropHelper(this);
        var hWnd = windowHelper.Handle;
        nint style = GetWindowLongPtr(hWnd, GWL_STYLE);
        style = style & ~WS_SYSMENU;
        SetWindowLongPtr(hWnd, GWL_STYLE, style);
        RegisterHotKey(hWnd, HOTKEY_ID, MOD_CONTROL | MOD_ALT, VK_SPACE);
        HwndSource.FromHwnd(windowHelper.Handle).AddHook(new HwndSourceHook(WndProc));
        style = GetWindowLong(hWnd, GWL_STYLE);

        // 清除窗口的大小调整边框相关的样式位
        style = style & ~WS_THICKFRAME;

        // 设置窗口的样式
        SetWindowLong(hWnd, GWL_STYLE, (int)style);
        var res = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
        DirectoryInfo dirinfo = new DirectoryInfo(res);
        
    }


    private nint WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
    {
        if (msg == WM_HOTKEY && wParam.ToInt32() == HOTKEY_ID)
        {
            if(this.Visibility == System.Windows.Visibility.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.Activate();
                this.Focus();
            }
            handled = true;
        }
        return IntPtr.Zero;
    }
}