using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Message
{
    public class KDVChangedMessage
    {
        public double KDV { get; set; }

        public KDVChangedMessage(double kdv)
        {
            KDV = kdv;
        }
    }
}
