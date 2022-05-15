using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Message;
using Neslihan_Kres_Makbuz.Model;
using Neslihan_Kres_Makbuz.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Neslihan_Kres_Makbuz.Helper;
using Neslihan_Kres_Makbuz.Converter;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class StudentScreenViewModel : ViewModelBase
    {
        IStudentService _studentService;

        public StudentScreenViewModel(IStudentService studentService)
        {
            #region Services

            #region Student Service
            _studentService = studentService;
            Students = _studentService.StudentList;  
            #endregion
            
            #endregion


            #region Messenger
            Messenger.Default.Register<SelectedStudentChangedMessage>(this, SelectedStudentChangedMessageMethod); 
            #endregion

            #region Commands
            DoubleClickCommand = new RelayCommand<object>(DoubleClickCommandMethod); 
            #endregion


            #region Filter
            ItemSourceList = new CollectionViewSource() { Source = Students };
            StudentView = ItemSourceList.View;
            StudentView.Filter = new Predicate<object>(StudentsFiltering); 
            #endregion
        }

        private bool StudentsFiltering(object obj)
        {
            Student s = (Student)obj;

            bool showStudent = true;

            if (!s.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                showStudent = false;

            if (HideDeactiveStudents && s.Status != STATUS.MEMBER)
                showStudent = false;

            if (HidePayers)
                if (s.Receipts.Count(f => f.CreateDate.Month == DateTime.Now.Month) > 0)
                    showStudent = false;

            if (!FilterFiveMoreSelected && s.SClass == CLASSES.FIVE_MORE)
                showStudent = false;
            if (!FilterFourSelected && s.SClass == CLASSES.FOUR)
                showStudent = false;
            if (!FilterThreeTwoSelected && s.SClass == CLASSES.THREE)
                showStudent = false;
            if (!FilterZeroTwoSelected && s.SClass == CLASSES.ZERO_TWO)
                showStudent = false;


            return showStudent;
        }

        private void SelectedStudentChangedMessageMethod(SelectedStudentChangedMessage newStudent)
        {
            if (newStudent.SelectedStudent == null)
            {
                SelectedStudent = newStudent.SelectedStudent;
            }
        }

        public ICommand DoubleClickCommand { get; private set; }
        private void DoubleClickCommandMethod(object obj)
        {
            SelectedStudent.Selected = !SelectedStudent.Selected;
        }




        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get => _students;
            set { Set<ObservableCollection<Student>>(() => this.Students, ref _students, value); }
        }

        private Student _selectedStudent = null;
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

        #region Filters

        private CollectionViewSource _itemSourceList;
        public CollectionViewSource ItemSourceList
        {
            get => _itemSourceList;
            set
            {
                Set<CollectionViewSource>(() => this.ItemSourceList, ref _itemSourceList, value);
            }
        }

        private ICollectionView _studentView;
        public ICollectionView StudentView
        {
            get => _studentView;
            set
            {
                Set<ICollectionView>(() => this.StudentView, ref _studentView, value);
            }
        }

        private bool _hideDeactiveStudents = true;
        public bool HideDeactiveStudents
        {
            get => _hideDeactiveStudents;
            set
            {
                Set<bool>(() => this.HideDeactiveStudents, ref _hideDeactiveStudents, value);
                ItemSourceList.View.Refresh();
            }
        }

        private bool _hidePayers;
        public bool HidePayers
        {
            get => _hidePayers;
            set
            {
                Set<bool>(() => this.HidePayers, ref _hidePayers, value);
                ItemSourceList.View.Refresh();
            }
        }

        private bool _selectAll;
        public bool SelectAll
        {
            get => _selectAll;
            set
            {
                Set<bool>(() => this.SelectAll, ref _selectAll, value);

                foreach (Student s in ItemSourceList.View)
                {
                    s.Selected = value;
                }
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                Set<string>(() => this.SearchText, ref _searchText, value);
                ItemSourceList.View.Refresh();
            }
        } 

        private bool _filterFiveMoreSelected = true;
        public bool FilterFiveMoreSelected
        {
            get => _filterFiveMoreSelected;
            set
            {
                Set<bool>(() => this.FilterFiveMoreSelected, ref _filterFiveMoreSelected, value);
                ItemSourceList.View.Refresh();
            }
        }

        private bool _filterFourSelected = true;
        public bool FilterFourSelected
        {
            get => _filterFourSelected;
            set
            {
                Set<bool>(() => this.FilterFourSelected, ref _filterFourSelected, value);
                ItemSourceList.View.Refresh();
            }
        }

        private bool _filterThreeTwoSelected = true;
        public bool FilterThreeTwoSelected
        {
            get => _filterThreeTwoSelected;
            set
            {
                Set<bool>(() => this.FilterThreeTwoSelected, ref _filterThreeTwoSelected, value);
                ItemSourceList.View.Refresh();
            }
        }

        private bool _filterZeroTwoSelected = true;
        public bool FilterZeroTwoSelected
        {
            get => _filterZeroTwoSelected;
            set
            {
                Set<bool>(() => this.FilterZeroTwoSelected, ref _filterZeroTwoSelected, value);
                ItemSourceList.View.Refresh();
            }
        }
        #endregion
    }
}
