﻿using FluentWPF.Models.Enums;
using System.Windows;
using System.Windows.Markup;

namespace FluentWPF;

[Localizability(LocalizationCategory.Ignore)]
[Ambient]
[UsableDuringInitialization(true)]
public sealed class FluentXamlResource : ResourceDictionary
{
    private ThemeTypeEnum type;

    public ThemeTypeEnum Type
    {
        set
        {
            switch (value)
            {
                case ThemeTypeEnum.Dark:
                    Source = new Uri($"{FluentUsings.ThemePath}Dark.xaml", UriKind.Absolute);
                    break;
                case ThemeTypeEnum.Light:
                    Source = new Uri($"{FluentUsings.ThemePath}Light.xaml", UriKind.Absolute);
                    break;
            }
            type = value;
        }
    }
}
