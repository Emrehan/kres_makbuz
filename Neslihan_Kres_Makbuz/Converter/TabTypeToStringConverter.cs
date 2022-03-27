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
using Neslihan_Kres_Makbuz.Config;

namespace Neslihan_Kres_Makbuz.Converter
{
    public class TabTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Null";
            if (value.GetType() != typeof(TAB_ITEM)) return "Wrong Type";

            switch ((TAB_ITEM)value)
            {
                case TAB_ITEM.STUDENTS: return "Öğrenciler";
                case TAB_ITEM.MENU: return "Yemek Listesi";
                default: return "Default";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}