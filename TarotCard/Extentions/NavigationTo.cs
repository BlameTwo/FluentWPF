using FluentWPF.Contracts.Navigations;
using System;
using System.Windows;

namespace TarotCard.Extentions;

public class NavigationTo
{
    public static Type GetNavigationKey(DependencyObject obj)
    {
        return (Type)obj.GetValue(NavigationKeyProperty);
    }

    public static void SetNavigationKey(DependencyObject obj, Type value)
    {
        obj.SetValue(NavigationKeyProperty, value);
    }


    public static readonly DependencyProperty NavigationKeyProperty =
        DependencyProperty.RegisterAttached("NavigationKey", typeof(Type), typeof(NavigationTo), new PropertyMetadata(null));


}
