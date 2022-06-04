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
        private ObservableCollection<Student> Students;
        private ObservableCollection<Receipt> Receipts;

        public ObservableCollection<Student> GetFilteredStudents(string filter)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Student> GetStudents()
        {
            //READ DB
            Students = new ObservableCollection<Student>(Student.FakeData.Generate(50).ToArray());
            Receipts = new ObservableCollection<Receipt>(Receipt.FakeData.Generate(1000).ToArray());

            Random rn = new Random();
            foreach (var r in Receipts)
            {
                var s = Students[rn.Next(Students.Count)];
                r.Student = s;
                s.Receipts.Add(r);
            }

            return Students;
        }

        public void UpdateStudent(Student student)
        {
            //UPDATE DB
            for (var i = 0; i < Students.Count; i++)
            {
                if (Students[i].ID == student.ID)
                {
                    Students[i] = student;
                    break;
                }
            }
        }

        public void UpdateStudents(ObservableCollection<Student> students)
        {
            //Update database with new values
        }

        public Student FindStudent(int id)
        {
            //ID
            return Students.FirstOrDefault(f => f.ID == id);
        }
    }
}
