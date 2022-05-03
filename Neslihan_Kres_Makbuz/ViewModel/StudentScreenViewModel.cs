using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Message;
using Neslihan_Kres_Makbuz.Model;
using Neslihan_Kres_Makbuz.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentScreenViewModel : ViewModelBase
    {
        IStudentService _studentService;

        public StudentScreenViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            Students = _studentService.StudentList;

            Messenger.Default.Register<SelectedStudentChangedMessage>(this, SelectedStudentChangedMessageMethod);

            DoubleClickCommand = new RelayCommand<object>(DoubleClickCommandMethod);
        }

        private void SelectedStudentChangedMessageMethod(SelectedStudentChangedMessage newStudent)
        {
            if (newStudent.SelectedStudent == null)
            {
                SelectedStudent = newStudent.SelectedStudent;
            }
        }

        private void DoubleClickCommandMethod(object obj)
        {
            SelectedStudent.Selected = !SelectedStudent.Selected;
        }

        private ObservableCollection<Student> _students;
        private Student _selectedStudent;

        public ICommand DoubleClickCommand { get; private set; }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set { Set<ObservableCollection<Student>>(() => this.Students, ref _students, value); }
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set 
            {
                if (value != null)
                {
                    Messenger.Default.Send(new SelectedStudentChangedMessage(value)); 
                }
                Set<Student>(() => this.SelectedStudent, ref _selectedStudent, value);
            }
        }
    }
}
