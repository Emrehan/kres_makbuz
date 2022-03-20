using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.ViewModel;

namespace Neslihan_Kres_Makbuz.Message
{
    internal class SelectedMenuChangedMessage
    {
        public TAB_ITEM SelectedMenu;

        public SelectedMenuChangedMessage(TAB_ITEM selectedMenu)
        {
            this.SelectedMenu = selectedMenu;
        }
    }
}