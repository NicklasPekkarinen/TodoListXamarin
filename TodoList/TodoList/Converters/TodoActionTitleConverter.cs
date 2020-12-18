using System;
using System.Globalization;
using Xamarin.Forms;

namespace TodoList.Converters
{
    public class TodoActionTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isDone = (bool) value;
            return isDone ? "Reset" : "Complete";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}