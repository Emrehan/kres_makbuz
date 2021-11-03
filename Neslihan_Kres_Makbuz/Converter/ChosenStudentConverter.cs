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
    public class ChosenStudentConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            ObservableCollection<Student> studentList = value as ObservableCollection<Student>;
            
            if (studentList == null)
            {
                throw new ArgumentException("Value is not a ObservableCollection<Student>.");
            }

            return studentList.Where(f => f.Chosen).ToList();
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            ObservableCollection<Student> studentList = value as ObservableCollection<Student>;

            if (studentList == null)
            {
                throw new ArgumentException("Value is not a ObservableCollection<Student>.");
            }

            return studentList.Where(f => f.Chosen).ToList();
        }
    }
}
