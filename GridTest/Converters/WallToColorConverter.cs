using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace GridTest.Converters
{
    public class WallToColorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isWall)
            {
                return isWall ? Brushes.Black : Brushes.White;
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}