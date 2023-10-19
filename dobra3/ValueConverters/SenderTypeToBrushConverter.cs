using Avalonia.Data.Converters;
using Avalonia.Media;
using dobra3.Sdk.Enums;
using System;
using System.Globalization;

namespace dobra3.ValueConverters
{
    internal sealed class SenderTypeToBrushConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not SenderType senderType)
                return new SolidColorBrush(Colors.Gray);

            return senderType switch
            {
                SenderType.Player => new SolidColorBrush(Colors.DodgerBlue),
                _ => new SolidColorBrush(Colors.Gray)
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
