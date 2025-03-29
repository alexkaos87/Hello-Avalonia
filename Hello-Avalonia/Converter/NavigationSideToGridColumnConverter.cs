using Avalonia.Data.Converters;
using HelloAvalonia.Data;
using System;
using System.Globalization;

namespace HelloAvalonia.Converter
{
    internal class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is NavigationSide navigationSide)
            {
                return navigationSide == NavigationSide.Left ? 0 : 2;
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
