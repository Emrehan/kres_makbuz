using GalaSoft.MvvmLight;
using Neslihan_Kres_Makbuz.Model;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentEditWindowViewModel : ViewModelBase
    {
        private Student _student;

        public StudentEditWindowViewModel()
        {
        }

        public Student Student
        {
            get
            {
                return _student;
            }
            set
            {
                Set<Student>(() => this.Student, ref _student, value);
            }
        }
    }
}
