using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace dobra3.ValueConverters
{
    internal sealed class BoolToFontWeightConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not bool bValue)
                return FontWeight.Normal;

            return bValue ? FontWeight.Bold : FontWeight.Normal;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
