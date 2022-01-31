using GalaSoft.MvvmLight;
using Neslihan_Kres_Makbuz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentScreenViewModel : ViewModelBase
    {
        public StudentScreenViewModel()
        {
            Students = new ObservableCollection<Student>(Student.FakeData.Generate(50).ToArray());
            Receipts = new ObservableCollection<Receipt>(Receipt.FakeData.Generate(6000).ToArray());

            Random rn = new Random();
            foreach (var r in Receipts)
            {
                var s = Students[rn.Next(Students.Count)];
                r.student = s;
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
            set { Set<Student>(() => this.SelectedStudent, ref _selectedStudent, value); }
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
    }
}
