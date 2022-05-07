using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Service
{
    public class DatabaseService : IDatabaseService
    {
        public ObservableCollection<Student> GetFilteredStudents(string filter)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Student> GetStudents()
        {
            var StudentList = new ObservableCollection<Student>(Student.FakeData.Generate(50).ToArray());
            var Receipts = new ObservableCollection<Receipt>(Receipt.FakeData.Generate(1000).ToArray());

            Random rn = new Random();
            foreach (var r in Receipts)
            {
                var s = StudentList[rn.Next(StudentList.Count)];
                r.Student = s;
                s.Receipts.Add(r);
            }

            return StudentList;
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudents(ObservableCollection<Student> students)
        {
            //Update database with new values
        }
    }
}
