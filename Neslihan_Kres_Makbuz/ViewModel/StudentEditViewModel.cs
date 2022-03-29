using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Message;
using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentEditViewModel : ViewModelBase
    {
        public StudentEditViewModel()
        {
            CloseStudentDetailCommand = new RelayCommand(CloseStudentDetailMethod);

            Messenger.Default.Register<SelectedStudentChangedMessage>(this, (SelectedStudentChangedMessage newStudent) =>
            {
                Student = newStudent.SelectedStudent;
            });
        }

        #region CloseStudentDetailCommand
        public ICommand CloseStudentDetailCommand { get; private set; }
        private void CloseStudentDetailMethod()
        {
            Messenger.Default.Send(new SelectedStudentChangedMessage(null));
        }
        #endregion

        #region Properties
        private Student _student;
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
        #endregion
    }
}
