using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Message;
using Neslihan_Kres_Makbuz.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class MainScreenViewModel : ViewModelBase
    {
        public MainScreenViewModel()
        {
            #region Commands
            CloseApplicationCommand = new RelayCommand(CloseApplicationMethod);
            MinimizeApplicationCommand = new RelayCommand(MinimizeApplicationMethod);
            MaximizeApplicationCommand = new RelayCommand(MaximizeApplicationMethod); 
            #endregion
        }

        WindowState _mainWindowState = WindowState.Maximized;
        public WindowState MainWindowState
        {
            get
            {
                return _mainWindowState;
            }
            set
            {
                Set<WindowState>(() => this.MainWindowState, ref _mainWindowState, value);
            }
        }


        public ICommand CloseApplicationCommand { get; private set; }
        private void CloseApplicationMethod()
        {
            Application.Current.Shutdown();
        }

        public ICommand MinimizeApplicationCommand { get; private set; }
        private void MinimizeApplicationMethod()
        {
            MainWindowState = WindowState.Minimized;
        }

        public ICommand MaximizeApplicationCommand { get; private set; }
        private void MaximizeApplicationMethod()
        {            
            MainWindowState = MainWindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

    }
}
