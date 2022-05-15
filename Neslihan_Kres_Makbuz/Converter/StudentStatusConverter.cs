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
    public class StudentStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            
            STATUS status = (STATUS)value;

            switch (status)
            {
                case STATUS.LEFT: return "Ayrıldı";
                case STATUS.MEMBER: return "Devam";
                case STATUS.GRADUATED: return "Mezun";
                default: return "Tanımsız";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "Ayrıldı": return STATUS.LEFT;
                case "Devam": return STATUS.MEMBER;
                case "Mezun": return STATUS.GRADUATED;
                default: return STATUS.STATUS_COUNT;
            }
        }
    }
}