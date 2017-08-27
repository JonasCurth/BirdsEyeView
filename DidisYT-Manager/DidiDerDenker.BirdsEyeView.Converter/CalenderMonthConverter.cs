using System;
using System.Globalization;
using System.Windows.Data;

namespace DidiDerDenker.BirdsEyeView.Converter
{
    public class CalenderMonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null != value)
            {
                return ((DateTime)value).AddMonths(1);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null != value)
            {
                return ((DateTime)value).AddMonths(-1);
            }

            return null;
        }
    }
}
