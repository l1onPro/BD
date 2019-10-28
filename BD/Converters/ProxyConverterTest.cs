using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BD.Converters
{
    class ProxyConverterTest : IValueConverter
    {
        private string user_string = null;

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (user_string != null)
            {
                return user_string;
            }

            double number = (double)value;
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}", number);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            string s_value = value.ToString();
            double result = 0;

            if (!double.TryParse(s_value, System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.CurrentCulture, out result))
                return null;

            user_string = s_value;

            return result;
        }
    }
}
