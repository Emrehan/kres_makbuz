using Bogus;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Neslihan_Kres_Makbuz.Config;
using Neslihan_Kres_Makbuz.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static int studentIDCount = 0;

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

        private bool chosen;

        private ObservableCollection<Receipt> receipts;

        public Student()
        {
            receipts = new ObservableCollection<Receipt>();

            Messenger.Default.Register<KDVChangedMessage>(this, (KDVChangedMessage) => CalculateFee() );
        }

        public override string ToString()
        {
            return Name + " " + tc;
        }

        #region PROPERTIES
        public static Faker<Student> FakeData { get; } =
            new Faker<Student>(locale: "tr")
                .RuleFor(p => p.ID, f => studentIDCount++)
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.TC, f => f.Random.Long(10000000000, 99999999999).ToString())
                .RuleFor(p => p.SClass, f => f.PickRandom<CLASSES>())
                .RuleFor(p => p.Sex, f => f.PickRandom<SEX>())
                .RuleFor(p => p.Status, f => f.PickRandom<STATUS>())
                .RuleFor(p => p.Fee, (f, p) => f.Random.Float(500, 2000))
                .RuleFor(p => p.Program_desc, f => f.Lorem.Sentence(3))
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.Chosen, f => f.Random.Bool());

        public int ID
        { 
            get => id; 
            set
            {
                Set<int>(() => this.ID, ref id, value);
            } 
        }

        public ObservableCollection<Receipt> Receipts
        {
            get => receipts;
            set
            {
                Set<ObservableCollection<Receipt>>(() => this.Receipts, ref receipts, value);
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

        public bool Chosen
        {
            get => chosen;
            set
            {
                Set<bool>(() => this.Chosen, ref chosen, value);
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
