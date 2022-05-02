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
    public class NavigationBarViewModel : ViewModelBase
    {
        public NavigationBarViewModel()
        {

        }

        private string _version = "2.0.0";
        public string Version
        {
            get => _version;
            set { Set<string>(() => this.Version, ref _version, value); }
        }
    }
}