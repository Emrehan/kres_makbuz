using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Neslihan_Kres_Makbuz.Converter
{
    public class MenuTypeToSelectedBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            if (parameter == null) return false;
            if (value.GetType() != typeof(TAB_ITEM)) return false;
            if (parameter.GetType() != typeof(TAB_ITEM)) return false;

            return ((TAB_ITEM)value) == ((TAB_ITEM)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}