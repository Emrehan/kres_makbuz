using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Service
{
    public interface IDatabaseService
    {
        void UpdateStudent(Student student);
        void UpdateStudents(ObservableCollection<Student> students);
        ObservableCollection<Student> GetStudents();
        ObservableCollection<Student> GetFilteredStudents(string filter);        
    }
}
