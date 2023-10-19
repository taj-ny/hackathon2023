using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using dobra3.Sdk.Enums;
using System;
using System.Globalization;

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
                SenderType.Player => new Bitmap(AssetLoader.Open(new("avares://dobra3/Assets/Player.png"))),
                SenderType.Friend => new Bitmap(AssetLoader.Open(new("avares://dobra3/Assets/Friend.png"))),
                _ => null
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
