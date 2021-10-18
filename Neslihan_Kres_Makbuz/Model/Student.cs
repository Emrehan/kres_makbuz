using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Model
{
    public enum CLASSES
    {
        ZERO_TWO,
        THREE,
        FOUR,
        FIVE_MORE
    }

    public enum SEX
    {
        BOY,
        GIRL
    }
    
    public enum STATUS
    {
        LEFT,
        MEMBER,
        GRADUATED
    }

    public class Student : ObservableObject
    {
        private int id;
        private string name;
        private string tc;
        private CLASSES sClass;
        private SEX sex;
        private STATUS status;

        private double fee;
        private double fee_wo_kdv;
        private double cuted_kdv;
        private string program_desc; //How many days student attemp
        private string address;

        public Student()
        {
            Messenger.Default.Register<KDVChangedMessage>(this, (KDVChangedMessage) => CalculateFee() );
        }

        #region PROPERTIES
        public int ID
        { 
            get => id; 
            set
            {
                Set<int>(() => this.ID, ref id, value);
            } 
        }

        public string Name
        {
            get => name;
            set
            {
                Set<string>(() => this.Name, ref name, value);
            }
        }

        public string TC
        {
            get => tc;
            set
            {
                Set<string>(() => this.TC, ref tc, value);
            }
        }

        public CLASSES SClass
        {
            get => sClass;
            set
            {
                Set<CLASSES>(() => this.SClass, ref sClass, value);
            }
        }

        public SEX Sex
        {
            get => sex;
            set
            {
                Set<SEX>(() => this.Sex, ref sex, value);
            }
        }

        public STATUS Status
        {
            get => status;
            set
            {
                Set<STATUS>(() => this.Status, ref status, value);
            }
        }

        public double Fee
        {
            get => fee;
            set
            {
                Set<double>(() => this.Fee, ref fee, value);

                CalculateFee();
            }
        }

        public double Fee_wo_kdv
        {
            get => fee_wo_kdv;
            private set
            {
                Set<double>(() => this.Fee_wo_kdv, ref fee_wo_kdv, value);
            }
        }

        public double Cuted_kdv
        {
            get => cuted_kdv;
            private set
            {
                Set<double>(() => this.Cuted_kdv, ref cuted_kdv, value);
            }
        }

        public string Program_desc
        {
            get => program_desc;
            set
            {
                Set<string>(() => this.Program_desc, ref program_desc, value);
            }
        }

        public string Address
        {
            get => address;
            set
            {
                Set<string>(() => this.Address, ref address, value);
            }
        }


        #endregion

        #region METHODS
        private void CalculateFee()
        {
            Fee_wo_kdv = Math.Round(((Fee * 100) / (100 + Globals.Instance.KDV)), 2);
            Cuted_kdv = Math.Round(Fee - this.Fee_wo_kdv, 2);
        }
        #endregion
    }
}
