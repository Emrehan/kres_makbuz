using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Message;
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

            #region Messages
            Messenger.Default.Register<SelectedMenuChangedMessage>(this, 
                (SelectedMenuChangedMessage newMessage) => { SelectedMenuType = newMessage.SelectedMenu; });
            #endregion
        }

        WindowState _mainWindowState;
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

        private TAB_ITEM _selectedMenuType = TAB_ITEM.STUDENTS;
        public TAB_ITEM SelectedMenuType
        {
            get
            {
                return _selectedMenuType;
            }
            set
            {
                Set<TAB_ITEM>(() => this.SelectedMenuType, ref _selectedMenuType, value);
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
