﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Message;
using Neslihan_Kres_Makbuz.Model;
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
        public StudentScreenViewModel()
        {
            CloseStudentDetailCommand = new RelayCommand(CloseStudentDetailMethod);

            Students = new ObservableCollection<Student>(Student.FakeData.Generate(50).ToArray());
            Receipts = new ObservableCollection<Receipt>(Receipt.FakeData.Generate(6000).ToArray());

            Random rn = new Random();
            foreach (var r in Receipts)
            {
                var s = Students[rn.Next(Students.Count)];
                r.Student = s;
                s.Receipts.Add(r);
            }
        }

        private ObservableCollection<Student> _students;
        private Student _selectedStudent;

        private ObservableCollection<Receipt> _receipts;
        private Receipt _selectedReceipt;

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
                Set<Student>(() => this.SelectedStudent, ref _selectedStudent, value);
                Messenger.Default.Send(new SelectedStudentChangedMessage(value));
            }
        }
        public ObservableCollection<Receipt> Receipts
        {
            get => _receipts;
            set { Set<ObservableCollection<Receipt>>(() => this.Receipts, ref _receipts, value); }
        }
        public Receipt SelectedReceipt
        {
            get => _selectedReceipt;
            set { Set<Receipt>(() => this.SelectedReceipt, ref _selectedReceipt, value); }
        }

        #region CloseStudentDetailCommand
        public ICommand CloseStudentDetailCommand { get; private set; }
        private void CloseStudentDetailMethod()
        {
            SelectedStudent = null;
        }
        #endregion
    }
}