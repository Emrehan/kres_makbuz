using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private string _version;
        private Globals _global;

        public MainViewModel()
        {
            Global = Globals.Instance;

            Students = new ObservableCollection<Student>();            
            for(int i = 0; i< 50; i++)
            {
                Students.Add(new Student()
                {
                    ID = i + 1,
                    Name = "name" + i,
                    Address = "adress " + i,
                    Fee = 1000 + 100 * i,
                    Program_desc = "desc " + i,
                    SClass = i % 2 == 0 ? CLASSES.FIVE_MORE : CLASSES.FOUR,
                    Sex = i % 2 == 0 ? SEX.BOY : SEX.GIRL,
                    Status = i % 10 != 0 ? STATUS.MEMBER : STATUS.LEFT,
                    TC = "11111"+i                    
                });
            }

            LoadEmployeesCommand = new RelayCommand(LoadEmployeesMethod);
            SaveEmployeesCommand = new RelayCommand(SaveEmployeesMethod);

            Version = "1.0";
        }

        public ICommand LoadEmployeesCommand { get; private set; }
        public ICommand SaveEmployeesCommand { get; private set; }

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

        public void SaveEmployeesMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved."));
        }

        private void LoadEmployeesMethod()
        {

        }
    }
}