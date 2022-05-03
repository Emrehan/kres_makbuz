using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Service
{
    public delegate void PageChangedDelegate(NavigationPage page);

    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
        event PageChangedDelegate PageChanged;
    }
}
