using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Linq;
using Neslihan_Kres_Makbuz.Converter;
using Neslihan_Kres_Makbuz.Message;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class TabButtonViewModel : ViewModelBase
    {
        private TAB_ITEM _menu;

        public TabButtonViewModel(TAB_ITEM menu)
        {
            _menu = menu;
            switch (_menu)
            {
                case TAB_ITEM.STUDENTS:
                    TabName = "Öðrenciler";
                    IsSelected = true;
                    break;
                case TAB_ITEM.MENU:
                    TabName = "Yemek Menüsü";
                    break;
                default:
                    TabName = "???WTF???";
                    break;
            }

            MouseClickCommand = new RelayCommand(MouseClickMethod);

            Messenger.Default.Register<SelectedMenuChangedMessage>(this, SelectedMenuChangedMethod);
        }

        public ICommand MouseClickCommand { get; private set; }
        public void MouseClickMethod()
        {
            Messenger.Default.Send(new SelectedMenuChangedMessage(_menu));
        }


        private void SelectedMenuChangedMethod(SelectedMenuChangedMessage obj)
        {
            IsSelected = obj.SelectedMenu == _menu;
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                Set<bool>(() => this.IsSelected, ref _isSelected, value);
            }
        }

        private string _tabName;
        public string TabName
        {
            get => _tabName;
            set
            {
                Set<string>(() => this.TabName, ref _tabName, value);
            }
        }
    }
}