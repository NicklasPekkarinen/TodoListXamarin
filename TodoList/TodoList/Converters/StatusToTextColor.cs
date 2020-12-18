using System;
using System.Globalization;
using Xamarin.Forms;

namespace TodoList.Converters
{
    public class StatusToTextColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isDone = (bool) value;
            var textColor = Color.Black;
            if (!isDone) return textColor;
            textColor = Color.Green;
            return textColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}