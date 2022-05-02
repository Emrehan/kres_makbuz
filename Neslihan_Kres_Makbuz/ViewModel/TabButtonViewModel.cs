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
using Neslihan_Kres_Makbuz.Service;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public class TabButtonViewModel : ViewModelBase
    {
        private static int _menuId = 0;

        IFrameNavigationService _navigationService;

        public TabButtonViewModel(IFrameNavigationService navigationService)
        {
            TabType = (NavigationPage)(_menuId++);
            if (TabType == NavigationPage.STUDENT_LIST)
                IsSelected = true;

            _navigationService = navigationService;

            MouseClickCommand = new RelayCommand(MouseClickMethod);
            _navigationService.PageChanged += _navigationService_PageChanged;
        }

        private void _navigationService_PageChanged(NavigationPage page)
        {
            IsSelected = page == _tabType;
        }

        public ICommand MouseClickCommand { get; private set; }
        public void MouseClickMethod()
        {
            _navigationService.NavigateTo(TabType.ToString());
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

        private NavigationPage _tabType;
        public NavigationPage TabType
        {
            get => _tabType;
            set
            {
                Set<NavigationPage>(() => this.TabType, ref _tabType, value);
            }
        }
    }
}