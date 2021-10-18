using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDN_Makbuz
{
    public class Makbuz_Bilgileri
    {
        public int id;
        public string sira_no = "SIRANO";
        public DateTime duzenlenme_tarihi;
        public string irsaliye_no = "IRSALİYE_NO";
        public int cocuk_bilgisi_id;
        public double kdv = DatabaseManager.kdv;

        public Makbuz_Bilgileri(int id, string sira_no, DateTime duzenlenme_tarihi, string irsaliye_no, int cocuk_bilgisi_id, double kdv)
        {
            this.id = id;
            this.sira_no = sira_no;
            this.duzenlenme_tarihi = duzenlenme_tarihi;
            this.irsaliye_no = irsaliye_no;
            this.cocuk_bilgisi_id = cocuk_bilgisi_id;
            this.kdv = kdv;
        }

        internal void DBye_Ekle()
        {
            this.id = DatabaseManager.Instance.Makbuz_Ekle(sira_no, duzenlenme_tarihi, irsaliye_no, cocuk_bilgisi_id, kdv);
        }
    }
}
