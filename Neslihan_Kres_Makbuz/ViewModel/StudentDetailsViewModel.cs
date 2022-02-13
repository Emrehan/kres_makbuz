using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Linq;
using Neslihan_Kres_Makbuz.Converter;
using Neslihan_Kres_Makbuz.Message;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentDetailsViewModel : ViewModelBase
    {

        public StudentDetailsViewModel()
        {
            Messenger.Default.Register<SelectedStudentChangedMessage>(this, (SelectedStudentChangedMessage newStudent) => 
            {
                Student = newStudent.SelectedStudent;
            });
        }

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