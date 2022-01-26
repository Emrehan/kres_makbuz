using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.ViewModel
{
    public enum MENUS
    {        
        STUDENTS,
        TEMP
    }

    public class MenuButtonViewModel : ViewModelBase
    {
        private MENUS _menu;
        public MENUS Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                Set<MENUS>(() => this.Menu, ref _menu, value);
            }
        }

        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                Set<bool>(() => this.Selected, ref _selected, value);
            }
        }
    }
}
