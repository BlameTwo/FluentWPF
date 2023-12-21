using FluentWPF.Common;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Shell;

namespace FluentWPF.Controls;

[TemplatePart(Name = "TitleColumn", Type = typeof(ColumnDefinition))]
[TemplatePart(Name = "CenterColumn", Type = typeof(ColumnDefinition))]
[TemplatePart(Name = "RightColumn", Type = typeof(ColumnDefinition))]
[TemplatePart(Name = "RightPaddingColumn", Type = typeof(ColumnDefinition))]
public partial class FluentWindow : Window
{
    public FluentWindow()
    {
        this.Loaded += FluentWindow_Initialized;
    }

    private void FluentWindow_Initialized(object? sender, EventArgs e)
    {
        Instance.UpdateTheme();
        this.UpdateTitlebar();
    }

    /// <summary>
    /// 更新标题栏
    /// </summary>
    private void UpdateTitlebar()
    {
        IntPtr hMenu = Methods.GetSystemMenu(this.WinHander, false);
        if (hMenu != IntPtr.Zero)
        {
            int menuItemCount = Methods.GetMenuItemCount(hMenu);
            IntPtr hdc = Methods.GetDC(WinHander);
            int dpi = Methods.GetDeviceCaps(hdc, Methods.LOGPIXELSX);
            Methods.ReleaseDC(WinHander, hdc);
            double dpiFactor = dpi / 96.0;
            int buttonWidth = (int)((Methods.GetSystemMetrics(Methods.SM_CXSIZE) - Methods.GetSystemMetrics(Methods.SM_CXSIZEFRAME) * 2) * dpiFactor);
            if (_rightpaddingPadding == null) return;
            var width = buttonWidth * 3;
            this._rightpaddingPadding.Width = new GridLength(width);
        }
    }

    public IntPtr WinHander => new WindowInteropHelper(this).Handle;



    public SystemBackdropBase SystemBackdrop
    {
        get { return (SystemBackdropBase)GetValue(SystemBackdropProperty); }
        set { SetValue(SystemBackdropProperty, value); }
    }
    public static readonly DependencyProperty SystemBackdropProperty =
        DependencyProperty.Register("SystemBackdrop", typeof(SystemBackdropBase), typeof(FluentWindow), new PropertyMetadata(null,OnBackdropChanged));

    private static void OnBackdropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is SystemBackdropBase sys && d is FluentWindow win)
        {
            sys.SetBackdrop();
        }
    }



    /// <summary>
    /// 标题栏右侧功能区
    /// </summary>
    public object RightContent
    {
        get { return (object)GetValue(RightContentProperty); }
        set { SetValue(RightContentProperty, value); }
    }

    public static readonly DependencyProperty RightContentProperty =
        DependencyProperty.Register("RightContent", typeof(object), typeof(FluentWindow), new PropertyMetadata(null));


    /// <summary>
    /// 标题栏居中内容
    /// </summary>
    public object TitlebarContent
    {
        get { return (object)GetValue(TitlebarContentProperty); }
        set { SetValue(TitlebarContentProperty, value); }
    }

    public static readonly DependencyProperty TitlebarContentProperty =
        DependencyProperty.Register("TitlebarContent", typeof(object), typeof(FluentWindow), new PropertyMetadata(null));


    #region 获得模板控件
    private ColumnDefinition _leftPadding;
    private ColumnDefinition _titlePadding;
    private ColumnDefinition _centerPadding;
    private ColumnDefinition _rightPadding;
    private ColumnDefinition _rightpaddingPadding;



    public override void OnApplyTemplate()
    {
        this._titlePadding = (ColumnDefinition)GetTemplateChild("TitleColumn");
        this._centerPadding = (ColumnDefinition)GetTemplateChild("CenterColumn");
        this._rightPadding = (ColumnDefinition)GetTemplateChild("RightColumn");
        this._rightpaddingPadding = (ColumnDefinition)GetTemplateChild("RightPaddingColumn");
        UpdateTitlebar();
        base.OnApplyTemplate();
    }
    #endregion

}