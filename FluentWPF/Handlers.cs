using FluentWPF.Contracts.Navigations;
using FluentWPF.Models;

namespace FluentWPF;
public delegate void ControlEventHandler<in Sender,in Arg>(Sender sender,Arg args)
    where Sender:DependencyObject
    where Arg:RoutedEventArgs;


public delegate void NavigationSelectionDelegate(NavigationView sender, NavigationSelectionChangedArgs item);