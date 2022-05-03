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
        private string _name;
        private string _tc;
        private CLASSES _sClass;
        private SEX _sex;
        private STATUS _status;

        private double _fee;
        private double fee_wo_kdv;
        private double _cutedKDV;
        private string _programDesc; //How many days student attemp
        private string _address;

        private bool _selected;

        private ObservableCollection<Receipt> receipts;

        public Student()
        {
            receipts = new ObservableCollection<Receipt>();

            Messenger.Default.Register<KDVChangedMessage>(this, (KDVChangedMessage) => CalculateFee() );
        }

        public override string ToString()
        {
            return Name + " " + TC;
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
                .RuleFor(p => p.ProgramDesc, f => f.Lorem.Sentence(3))
                .RuleFor(p => p.Address, f => f.Address.FullAddress())
                .RuleFor(p => p.Selected, f => f.Random.Bool());

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
            get => _name;
            set
            {
                Set<string>(() => this.Name, ref _name, value);
            }
        }

        public string TC
        {
            get => _tc;
            set
            {
                Set<string>(() => this.TC, ref _tc, value);
            }
        }

        public CLASSES SClass
        {
            get => _sClass;
            set
            {
                Set<CLASSES>(() => this.SClass, ref _sClass, value);
            }
        }

        public SEX Sex
        {
            get => _sex;
            set
            {
                Set<SEX>(() => this.Sex, ref _sex, value);
            }
        }

        public STATUS Status
        {
            get => _status;
            set
            {
                Set<STATUS>(() => this.Status, ref _status, value);
            }
        }

        public double Fee
        {
            get => _fee;
            set
            {
                Set<double>(() => this.Fee, ref _fee, Math.Round(value,2));

                CalculateFee();
            }
        }

        public double Fee_wo_kdv
        {
            get => fee_wo_kdv;
            private set
            {
                Set<double>(() => this.Fee_wo_kdv, ref fee_wo_kdv, Math.Round(value, 2));
            }
        }

        public double CutedKDV
        {
            get => _cutedKDV;
            private set
            {
                Set<double>(() => this.CutedKDV, ref _cutedKDV, Math.Round(value, 2));
            }
        }

        public string ProgramDesc
        {
            get => _programDesc;
            set
            {
                Set<string>(() => this.ProgramDesc, ref _programDesc, value);
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                Set<string>(() => this.Address, ref _address, value);
            }
        }

        public bool Selected
        {
            get => _selected;
            set
            {
                Set<bool>(() => this.Selected, ref _selected, value);
            }
        }


        #endregion

        #region METHODS
        private void CalculateFee()
        {
            Fee_wo_kdv = Math.Round(((Fee * 100) / (100 + Globals.Instance.KDV)), 2);
            CutedKDV = Math.Round(Fee - this.Fee_wo_kdv, 2);
        }
        #endregion
    }
}
