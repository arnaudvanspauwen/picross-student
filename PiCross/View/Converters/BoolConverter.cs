using System;
using System.Windows.Data;

namespace View.Converters
{
    public class BoolConverter : IValueConverter
    {
        public object True { get; set; }

        public object False { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var b = (bool)value;
            return b ? True : False;

        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}