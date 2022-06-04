using Neslihan_Kres_Makbuz.Helper;
using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Service
{
    public class StudentService : IStudentService
    {
        private readonly IDatabaseService _databaseService;

        public StudentService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;

            StudentList = _databaseService.GetStudents();
        }

        private ObservableCollection<Student> _studentList; 
        public ObservableCollection<Student> StudentList 
        {
            get
            {
                return _studentList;
            }
            set
            {
                _studentList = value;
            }
        }

        public ObservableCollection<Student> FilterStudents()
        {
            throw new NotImplementedException();
        }

        public Student FindStudent(int id)
        {
            return _databaseService.FindStudent(id);
        }

        public void UpdateStudent(Student student)
        {
            _databaseService.UpdateStudent(student);
        }
    }
}
