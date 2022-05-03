using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Service
{
    public interface IStudentService
    {
        ObservableCollection<Student> StudentList { get; set; }

        Student FindStudent(int id);
        void UpdateStudent(Student student);
        ObservableCollection<Student> FilterStudents();
    }
}
