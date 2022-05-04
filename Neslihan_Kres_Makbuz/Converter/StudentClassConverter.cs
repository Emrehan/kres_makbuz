using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Neslihan_Kres_Makbuz.Converter
{
    public class StudentClassConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            
            CLASSES status = (CLASSES)value;

            switch (status)
            {
                case CLASSES.ZERO_TWO: return "0-2";
                case CLASSES.THREE: return "3";
                case CLASSES.FOUR: return "4";
                case CLASSES.FIVE_MORE: return "5+";
                default: return "Tanımsız";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return CLASSES.ZERO_TWO;

            string status = (string)value;

            switch (status)
            {
                case "0-2": return CLASSES.ZERO_TWO;
                case "3": return CLASSES.THREE;
                case "4": return CLASSES.FOUR;
                case "5+": return CLASSES.FIVE_MORE;
                default: return CLASSES.ZERO_TWO;
            }
        }
    }
}