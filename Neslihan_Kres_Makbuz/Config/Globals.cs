using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Config
{
    public class Globals : ObservableObject
    {
        private double kdv;
        
        private static Globals _instance;
        private static readonly object lock_object = new object();

        private Globals()
        {
            kdv = 18.0;
        }

        public static Globals Instance
        {
            get
            {
                lock (lock_object)
                {
                    if (_instance == null)
                    {
                        _instance = new Globals();
                    }

                    return _instance; 
                }
            }            
        }

        public double KDV
        {
            get => kdv;
            set
            {
                Set<double>(() => this.KDV, ref kdv, value);

                Messenger.Default.Send(new KDVChangedMessage(value));
            }
        }
    }
}
