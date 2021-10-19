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
        private int id;
        private string serial;
        private DateTime createDate;
        private string waybillNo;
        private Student _student;
        private double kdv;

        #region PROPERTIES
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
        public Student student
        {
            get => _student;
            set
            {
                Set<Student>(() => this.student, ref _student, value);
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
