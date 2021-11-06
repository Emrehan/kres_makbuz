using Neslihan_Kres_Makbuz.Model;
using Neslihan_Kres_Makbuz.ViewModel;
using System.Windows;

namespace Neslihan_Kres_Makbuz.View
{
    /// <summary>
    /// Interaction logic for StudentEditWindow.xaml
    /// </summary>
    public partial class StudentEditWindow : Window
    {
        public StudentEditWindow(Student student)
        {
            InitializeComponent();

            ((StudentEditWindowViewModel)this.DataContext).Student = student;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
