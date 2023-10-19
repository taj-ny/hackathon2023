using Avalonia.Data.Converters;
using dobra3.Sdk.Enums;
using System;
using System.Globalization;

namespace dobra3.ValueConverters
{
    internal sealed class SenderTypeToImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not SenderType senderType)
                return null;

            return senderType switch
            {
                SenderType.Player => null,
                SenderType.Friend => null,
                _ => null
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
