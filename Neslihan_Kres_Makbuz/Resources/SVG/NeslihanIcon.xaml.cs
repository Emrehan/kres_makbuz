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
using System.Windows.Threading;

namespace Neslihan_Kres_Makbuz.Resources.SVG
{
    /// <summary>
    /// Interaction logic for NeslihanIcon.xaml
    /// </summary>
    public partial class NeslihanIcon : UserControl, INotifyPropertyChanged
    {
        private Thickness _boyOffset;
        public Thickness BoyOffset
        {
            get => _boyOffset;
            set
            {
                _boyOffset = value;
                NotifyPropertyChanged("BoyOffset");
            }
        }

        private Thickness _girlOffset;
        public Thickness GirlOffset
        {
            get => _girlOffset;
            set
            {
                _girlOffset = value;
                NotifyPropertyChanged("GirlOffset");
            }
        }

        private const int MAX_RANGE = 80;
        private const int MAX_MOVE = 1;

        private DispatcherTimer timer;
        private Random rn;

        public NeslihanIcon()
        {
            InitializeComponent();
            DataContext = this;

            rn = new Random(141);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(60);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var moveX = rn.Next(-MAX_MOVE, MAX_MOVE + 1);
            var moveY = rn.Next(-MAX_MOVE, MAX_MOVE + 1);

            moveX = rn.Next(-MAX_MOVE, MAX_MOVE + 1);
            moveY = rn.Next(-MAX_MOVE, MAX_MOVE + 1);

            GirlOffset = new Thickness(BoyOffset.Left + moveX, BoyOffset.Top + moveY, 0, 0);
            BoyOffset = new Thickness(BoyOffset.Left - moveX, BoyOffset.Top - moveY, 0, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
