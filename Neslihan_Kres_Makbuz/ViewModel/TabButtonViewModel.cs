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

        public TabButtonViewModel(TAB_ITEM menu)
        {
            TabType = menu;

            if (TabType == TAB_ITEM.STUDENTS)
                IsSelected = true;

            MouseClickCommand = new RelayCommand(MouseClickMethod);

            Messenger.Default.Register<SelectedMenuChangedMessage>(this, SelectedMenuChangedMethod);
        }

        public ICommand MouseClickCommand { get; private set; }
        public void MouseClickMethod()
        {
            Messenger.Default.Send(new SelectedMenuChangedMessage(_tabType));
        }


        private void SelectedMenuChangedMethod(SelectedMenuChangedMessage obj)
        {
            IsSelected = obj.SelectedMenu == _tabType;
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

        private TAB_ITEM _tabType;
        public TAB_ITEM TabType
        {
            get => _tabType;
            set
            {
                Set<TAB_ITEM>(() => this.TabType, ref _tabType, value);
            }
        }
    }
}