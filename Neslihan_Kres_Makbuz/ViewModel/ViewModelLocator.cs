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
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Service;
using System;
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

            SetupNavigation();

            SimpleIoc.Default.Register<IDatabaseService, DatabaseService>();
            SimpleIoc.Default.Register<IStudentService, StudentService>();

            SimpleIoc.Default.Register<MainScreenViewModel>();
            SimpleIoc.Default.Register<StudentScreenViewModel>(true);
            SimpleIoc.Default.Register<StudentDetailsViewModel>(true);
            SimpleIoc.Default.Register<StudentEditViewModel>(true);
            SimpleIoc.Default.Register<TabButtonViewModel>();
            SimpleIoc.Default.Register<NavigationBarViewModel>();
            SimpleIoc.Default.Register<FoodMenuViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure(NavigationPage.STUDENT_LIST.ToString(), new Uri("../View/StudentScreenView.xaml", UriKind.Relative));
            navigationService.Configure(NavigationPage.FOOD_MUNU.ToString(), new Uri("../View/FoodMenuView.xaml", UriKind.Relative));            

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public MainScreenViewModel MainScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainScreenViewModel>();
            }
        }

        public StudentScreenViewModel StudentScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentScreenViewModel> ();
            }
        }

        public StudentDetailsViewModel StudentDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentDetailsViewModel> ();
            }
        }

        public StudentEditViewModel StudentEdit
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentEditViewModel> ();
            }
        }

        private static int _menuID = 0;
        public TabButtonViewModel TabButton
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TabButtonViewModel>((_menuID++).ToString());
            }
        }

        public NavigationBarViewModel NavigationBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationBarViewModel>();
            }
        }

        public FoodMenuViewModel FoodMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FoodMenuViewModel>();
            }
        }


        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}