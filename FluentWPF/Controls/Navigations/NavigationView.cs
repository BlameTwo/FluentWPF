﻿using FluentWPF.Common.Bases;
using FluentWPF.Contracts.Navigations;
using System.Windows.Markup;
using System.Windows.Media;

namespace FluentWPF.Controls;

[ContentProperty(nameof(Content))]
[TemplateVisualState(GroupName = "OpenPanelStateGroup",Name = "Open")]
[TemplateVisualState(GroupName = "OpenPanelStateGroup",Name = "Close")]
[TemplatePart(Name = "OpenMenuButton",Type =typeof(FluentButton))]
public partial class NavigationView : ControlBase, INavigationView
{
    private FluentButton _openMenubth;

    public NavigationView()
    {
        this.NavigationParent = this;
    }

    public override void OnApplyTemplate()
    {
        this._openMenubth = (FluentButton)GetTemplateChild("OpenMenuButton");
        _openMenubth.Click += _openMenubth_Click;
        base.OnApplyTemplate();
    }

    private void _openMenubth_Click(object sender, RoutedEventArgs e)
    {
        this.DisplayMode = this.DisplayMode == NavigationDisplay.Open ? NavigationDisplay.Close : NavigationDisplay.Open;
    }
}
