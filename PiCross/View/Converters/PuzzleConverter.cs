using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.converters
{

    public class PuzzleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            char[] textChar = value.ToString().ToCharArray();
            string firstnumber = textChar[11].ToString();
            string secondnumber = textChar[11].ToString();

            String text = " SIZE PUZZLE: " + firstnumber + " BY " + secondnumber;
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}