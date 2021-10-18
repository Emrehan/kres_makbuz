using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using Newtonsoft;

namespace HDN_Makbuz
{
    public partial class Ana_Ekran : Form
    {
        Bitmap basilacak_resim;
        Bitmap gosterilecek_resim;

        public Ana_Ekran()
        {
            InitializeComponent();
        }

        private void Ana_Ekran_Load(object sender, EventArgs e)
        {
            DatabaseManager.Instance.ExceptionThrown += Instance_ExceptionThrown;
            DatabaseManager.Instance.connectDatabase();

            printDocument1.PrintPage += PrintDocument1_PrintPage;

            label_versiyon.Text = "0.0.5";

            cocuk_Listesi.Ekran_Kapandi += Cocuk_Listesi_Ekran_Kapandi;

            DatabaseManager.kdv = DatabaseManager.Instance.KDV_Al();
            numericUpDown1.Value = (int)DatabaseManager.kdv;
        }

        private void Cocuk_Listesi_Ekran_Kapandi()
        {
            if (cocuk_Listesi.cocuklar.Count != 0)
            {
                label_cocuk_sayisi.Text = cocuk_Listesi.cocuklar.Count + " Çocuk Seçildi";
                button_yazdir.Enabled = true;
            }
            else
            {
                label_cocuk_sayisi.Text = "";
                button_yazdir.Enabled = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DatabaseManager.Instance.closeDatabase();

            base.OnClosing(e);
        }

        private void Instance_ExceptionThrown(Exception e)
        {
            var result = MessageBox.Show(@"Hata! Bunun resmini çekip Emrehan'a gönderiniz. \n\n " + e, "Hata", MessageBoxButtons.OK);            
        }

        private string DateTime2DayName(DateTime date)
        {
            switch (date.Month)
            {
                case 1 : return "Ocak";
                case 2 : return "Şubat";
                case 3 : return "Mart";
                case 4 : return "Nisan";
                case 5 : return "Mayıs";
                case 6 : return "Haziran";
                case 7 : return "Temmuz";
                case 8 : return "Ağustos";
                case 9 : return "Eylül";
                case 10: return "Ekim";
                case 11: return "Kasım";
                case 12: return "Aralık";
                default: return "Not Possb.";
            }

        }

        private void button_cocuk_sec_Click(object sender, EventArgs e)
        {
            cocuk_Listesi.Show();
            cocuk_Listesi.Dock = DockStyle.Fill;
            cocuk_Listesi.BringToFront();
            cocuk_Listesi.Yenile();

           // DatabaseManager.Instance.Cocuklari_Kaydet();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (DatabaseManager.kdv == (double)numericUpDown1.Value)
            {
                return;
            }

            DatabaseManager.kdv = (double)numericUpDown1.Value;
            DatabaseManager.Instance.KDV_Kaydet(DatabaseManager.kdv);

            foreach (var cocuk in DatabaseManager.Instance.Cocuklar)
            {
                cocuk.Ucret_Hesapla(DatabaseManager.kdv, cocuk.aylik_ucret);
            }
            DatabaseManager.Instance.Cocuklari_Kaydet();
            cocuk_Listesi.Yenile();
        }

        private void button_yazdir_Click(object sender, EventArgs e)
        {            
            foreach(var cocuk in cocuk_Listesi.cocuklar)
            {
                basilacak_resim = Resim_Al(cocuk, Properties.Resources.bos_makbuz);
                gosterilecek_resim = Resim_Al(cocuk, Properties.Resources.makbuz);

                On_Izleme on_izleme = new On_Izleme();
                on_izleme.pictureBox.BackgroundImage = gosterilecek_resim;

                if (on_izleme.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }
        
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (basilacak_resim == null)
            {
                return;
            }

            e.Graphics.DrawImage(basilacak_resim, 0, 0);
            basilacak_resim.Dispose();
            basilacak_resim = null;
        }

        private Bitmap Resim_Al(Cocuk_Bilgileri cocuk, Bitmap bitmap)
        {
            var adres = cocuk.adres;
            var tarih = dateTimePicker_tarih.Value;

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawString(cocuk.cocuk_adi + " - " + cocuk.tc_no                                   , new Font("Arial", 13), Brushes.Black, new PointF(95f, 210f));
                graphics.DrawString(tarih.ToString("dd.MM.yyyy")                                            , new Font("Arial", 11), Brushes.Black, new PointF(642f, 301f));

                graphics.DrawString(cocuk.aylik_ucret_kdvsiz + " TL"                                        , new Font("Arial", 12), Brushes.Black, new PointF(643f, 403f));
                graphics.DrawString(DateTime2DayName(tarih) + " " + tarih.ToString("yyyy") + " kreş ücreti" , new Font("Arial", 11), Brushes.Black, new PointF(60f, 403f));
                graphics.DrawString(cocuk.duzen_metin                                                       , new Font("Arial", 11), Brushes.Black, new PointF(62f, 436f));

                graphics.DrawString("Ara Toplam"                    , new Font("Arial", 12), Brushes.Black  , new PointF(509f, 885f));
                graphics.DrawString("KDV %" + DatabaseManager.kdv   , new Font("Arial", 12), Brushes.Black  , new PointF(509f, 911f));
                graphics.DrawString("Genel Toplam"                  , new Font("Arial", 12), Brushes.Black  , new PointF(509f, 937f));

                graphics.DrawString(cocuk.aylik_ucret_kdvsiz + " TL", new Font("Arial", 12), Brushes.Black  , new PointF(640f, 885f));
                graphics.DrawString(cocuk.kesilen_kdv + " TL"       , new Font("Arial", 12), Brushes.Black  , new PointF(640f, 911f));
                graphics.DrawString(cocuk.aylik_ucret + " TL"       , new Font("Arial", 12), Brushes.Black  , new PointF(640f, 937f));



                var parcalar = GetNextChars(adres, 50);
                float yukseklik = 238f;
                foreach(var parca in parcalar)
                {
                    graphics.DrawString(parca, new Font("Arial", 9), Brushes.Black, new PointF(60f, yukseklik));
                    yukseklik += 19;
                }
            }
            //bitmap.Save(@"C:\Users\Emrehan\Desktop\abc.jpg");
            return bitmap;
        }

        IEnumerable<string> GetNextChars(string str, int iterateCount)
        {
            var words = new List<string>();

            for (int i = 0; i < str.Length; i += iterateCount)
                if (str.Length - i >= iterateCount) words.Add(str.Substring(i, iterateCount));
                else words.Add(str.Substring(i, str.Length - i));

            return words;
        }
    }
}
