using DidiDerDenker.BirdsEyeView.Objects;
using DidiDerDenker.BirdsEyeView.Operations.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DidiDerDenker.BirdsEyeView.Converter
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null != value && value is Enum)
            {
                return ((Enum)value).GetDisplayName(Language.EN);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Can not revert the localization.");
        }
    }
}
