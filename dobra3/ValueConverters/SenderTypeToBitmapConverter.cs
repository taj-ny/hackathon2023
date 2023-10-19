using Avalonia.Data.Converters;
using dobra3.Sdk.Enums;
using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace dobra3.ValueConverters
{
    internal sealed class SenderTypeToBitmapConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not SenderType senderType)
                return null;

            return senderType switch
            {
                SenderType.Player => new Bitmap(AssetLoader.Open(new("avares://dobra3/Assets/user-128.png"))),
                SenderType.Friend => new Bitmap(AssetLoader.Open(new("avares://dobra3/Assets/pawel-nierodka-w-ramce.png"))),
                _ => null
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
