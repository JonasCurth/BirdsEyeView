using DidiDerDenker.BirdsEyeView.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace DidiDerDenker.BirdsEyeView.Converter
{
    public class LanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object x = Application.Current.TryFindResource($"Task_{value.ToString()}");
            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
            //if(value is String)
            //{
            //    string[] x = value.ToString().Split('_');
            //    Task task;
            //    Application.Current.Find
            //    return Enum.TryParse<Task>(x[1], );
            //}

            //return null;
        }
    }
}
