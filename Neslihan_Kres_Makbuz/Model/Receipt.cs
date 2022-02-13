using Bogus;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neslihan_Kres_Makbuz.Model
{
    public class Receipt : ObservableObject
    {
        private static int receiptIDCount = 0;

        private int id;
        private string serial;
        private DateTime createDate;
        private string waybillNo;
        private Student _student;
        private double kdv;

        #region PROPERTIES
        public static Faker<Receipt> FakeData { get; } =
            new Faker<Receipt>(locale: "tr")
                .RuleFor(p => p.ID, f => receiptIDCount++)
                .RuleFor(p => p.Serial, f => f.Lorem.Sentence(3))
                .RuleFor(p => p.CreateDate, f => f.Date.Future())
                .RuleFor(p => p.WaybillNo, f => f.Lorem.Sentence(3));


        public int ID
        {
            get => id;
            set
            {
                Set<int>(() => this.ID, ref id, value);
            }
        }
        public string Serial
        {
            get => serial;
            set
            {
                Set<string>(() => this.Serial, ref serial, value);
            }
        }
        public DateTime CreateDate
        {
            get => createDate;
            set
            {
                Set<DateTime>(() => this.CreateDate, ref createDate, value);
            }
        }
        public string WaybillNo
        {
            get => waybillNo;
            set
            {
                Set<string>(() => this.WaybillNo, ref waybillNo, value);
            }
        }
        public Student Student
        {
            get => _student;
            set
            {
                Set<Student>(() => this.Student, ref _student, value);
            }
        }
        public double KDV
        {
            get => kdv;
            set
            {
                Set<double>(() => this.KDV, ref kdv, value);
            }
        }

        #endregion
    }
}
