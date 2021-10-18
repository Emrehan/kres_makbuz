using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HDN_Makbuz.DatabaseManager;

namespace HDN_Makbuz
{
    public class Cocuk_Bilgileri
    {
        public int id;
        public string cocuk_adi;
        public string tc_no;
        public SINIFLAR sinif;
        public CINSIYET cinsiyet;
        public AKTIFLIK aktif_mi;

        public double aylik_ucret;
        public double aylik_ucret_kdvsiz;
        public double kesilen_kdv;
        public string duzen_metin;
        public string adres;
        public bool guncelle = false;

        public Cocuk_Bilgileri(int id, string cocuk_adi, string adres, string tc_no, string duzen_metni, double aylik_ucret, SINIFLAR sinif, CINSIYET cinsiyet, AKTIFLIK aktif_mi)
        {
            this.id = id;
            this.cocuk_adi = cocuk_adi;
            this.adres = adres;
            this.tc_no = tc_no;
            this.aylik_ucret = aylik_ucret;
            this.sinif = sinif;
            this.cinsiyet = cinsiyet;
            this.aktif_mi = aktif_mi;
            this.duzen_metin = duzen_metni;

            Ucret_Hesapla(DatabaseManager.kdv, aylik_ucret);
        }

        public void Ucret_Hesapla(double kdv, double ucret)
        {
            this.aylik_ucret = ucret;

            this.aylik_ucret_kdvsiz = Math.Round(((ucret * 100) / (100 + kdv)), 2);
            this.kesilen_kdv = Math.Round(ucret - this.aylik_ucret_kdvsiz, 2);
        }

        public void DBye_Ekle()
        {
            this.id = DatabaseManager.Instance.Cocuk_Ekle(cocuk_adi, adres, tc_no, duzen_metin, aylik_ucret, sinif, cinsiyet);
        }

        
    }
}
