/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Neslihan_Kres_Makbuz"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainScreenViewModel>();
            SimpleIoc.Default.Register<StudentEditWindowViewModel>();
            SimpleIoc.Default.Register<MenuButtonViewModel>();
            SimpleIoc.Default.Register<StudentScreenViewModel>(true);
        }

        public MainScreenViewModel MainScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainScreenViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public StudentEditWindowViewModel StudentEditWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentEditWindowViewModel>();
            }
        }

        public MenuButtonViewModel MenuButton
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MenuButtonViewModel > ();
            }
        }

        public StudentScreenViewModel StudentScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentScreenViewModel> ();
            }
        }


        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}