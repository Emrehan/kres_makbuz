using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    /// <summary>
    /// Interaction logic for MenuButtonView.xaml
    /// </summary>
    public partial class MenuButtonView : UserControl, INotifyPropertyChanged
    {
        public MenuButtonView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        private bool _hover;
        public bool Hover
        {
            get => _hover;
            set
            {
                _hover = value;
                OnPropertyChanged("Selected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propetyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propetyName));

        }
    }
}
