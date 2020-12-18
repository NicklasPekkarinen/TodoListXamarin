using System;
using System.Globalization;
using Xamarin.Forms;

namespace TodoList.Converters
{
    public class StatusToSymbol : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isDone = (bool) value;
            var isDoneString = "";
            if (!isDone) return isDoneString;
            isDoneString = ((char)0x2713).ToString();
            return isDoneString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}