using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Message
{
    class SelectedStudentChangedMessage
    {
        public Student SelectedStudent;

        public SelectedStudentChangedMessage(Student selectedStudent)
        {
            SelectedStudent = selectedStudent;
        }
    }
}
