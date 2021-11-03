using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;

        private ObservableCollection<Receipt> _receipts;
        private Receipt _selectedReceipt;

        private string _version;
        private Globals _global;

        public MainViewModel()
        {
            Global = Globals.Instance;

            Students = new ObservableCollection<Student>( Student.FakeData.Generate(50).ToArray() );
            Receipts = new ObservableCollection<Receipt>( Receipt.FakeData.Generate(6000).ToArray() );

            Random rn = new Random();
            foreach (var r in Receipts)
            {
                var s = Students[rn.Next(Students.Count)];
                r.student = s;
                s.Receipts.Add(r);
            }

            EditStudentCommand = new RelayCommand(EditStudentMethod);

            Version = "1.0";
        }

        public ICommand EditStudentCommand { get; private set; }

        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                Set<string>(() => this.Version, ref _version, value);
            }
        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                Set<ObservableCollection<Student>>(() => this.Students, ref _students, value);
            }
        }

        public Receipt SelectedReceipt
        {
            get
            {
                return _selectedReceipt;
            }
            set
            {
                Set<Receipt>(() => this.SelectedReceipt, ref _selectedReceipt, value);
            }
        }

        public ObservableCollection<Receipt> Receipts
        {
            get
            {
                return _receipts;
            }
            set
            {
                Set<ObservableCollection<Receipt>>(() => this.Receipts, ref _receipts, value);
            }
        }

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                Set<Student>(() => this.SelectedStudent, ref _selectedStudent, value);
            }
        }

        public Globals Global
        {
            get
            {
                return _global;
            }
            set
            {
                Set<Globals>(() => this.Global, ref _global, value);
            }
        }

        private void EditStudentMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved."));
        }
    }
}