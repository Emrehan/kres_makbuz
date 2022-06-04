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
using System.Windows;
using Neslihan_Kres_Makbuz.Service;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentEditViewModel : ViewModelBase
    {
        private Student baseStudent;
        private readonly IStudentService _studentService;
        public StudentEditViewModel(IStudentService studentService)
        {
            _studentService = studentService;

            CancelCommand = new RelayCommand(CancelMethod);
            SaveCommand = new RelayCommand(SaveMethod);
            ChangeClassCommand = new RelayCommand(ChangeClassMethod);
            ChangeStatusCommand = new RelayCommand(ChangeStatusMethod);

            Messenger.Default.Register<SelectedStudentChangedMessage>(this, SelectedStudentChangedMethod);
        }

        private void SelectedStudentChangedMethod(SelectedStudentChangedMessage newStudent)
        {
            baseStudent = newStudent.SelectedStudent;
            EditedStudent = newStudent.SelectedStudent.Clone();
            ScreenVisibility = Visibility.Collapsed;
        }

        #region CloseStudentDetailCommand
        public ICommand CancelCommand { get; private set; }
        private void CancelMethod()
        {
            ScreenVisibility = Visibility.Collapsed;
        }

        public ICommand SaveCommand { get; private set; }
        private void SaveMethod()
        {
            _studentService.UpdateStudent(EditedStudent);
            ScreenVisibility = Visibility.Collapsed;
        }

        public ICommand ChangeStatusCommand { get; private set; }
        private void ChangeStatusMethod()
        {
            var index = (int)EditedStudent.Status + 1;

            if (index >= (int)STATUS.STATUS_COUNT)
                index = 0;

            EditedStudent.Status = (STATUS)index;
        }

        public ICommand ChangeClassCommand { get; private set; }
        private void ChangeClassMethod()
        {
            var index = (int)EditedStudent.SClass + 1;

            if (index >= (int)CLASSES.CLASS_COUNT)
                index = 0;

            EditedStudent.SClass = (CLASSES)index;
        }
        #endregion

        #region Properties
        private Student _editedStudent;
        public Student EditedStudent
        {
            get
            {
                return _editedStudent;
            }
            set
            {
                Set<Student>(() => this.EditedStudent, ref _editedStudent, value);
            }
        }

        private Visibility _screenVisibility = Visibility.Collapsed ;
        public Visibility ScreenVisibility
        {
            get
            {
                return _screenVisibility;
            }
            set
            {
                Set<Visibility>(() => this.ScreenVisibility, ref _screenVisibility, value);

                EditedStudent = baseStudent.Clone();
            }
        }
        #endregion

    }
}