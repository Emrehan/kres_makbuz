using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDN_Makbuz
{
    public partial class Cocuk_Listesi : UserControl
    {
        private enum Sutunlar { ID, AD, ADRES, TC, DUZEN, AYLIK, AYLIK_KDVSIZ, KESILEN_KDV, SINIF, CINSIYET, AKTIF, SEC }
        public List<Cocuk_Bilgileri> cocuklar = new List<Cocuk_Bilgileri>();

        private readonly string onayli  = "✔";
        private readonly string onaysiz = "✘";

        private bool devam_etmeyenleri_goster = false;

        public delegate void Ekran_Kapandi_Delegate();
        public event Ekran_Kapandi_Delegate Ekran_Kapandi;
        public Cocuk_Listesi()
        {
            InitializeComponent();
        }

        public void Yenile()
        {
            if (DatabaseManager.Instance.Cocuklar.Count == 0)
            {
                return;
            }

            dataGridView1.Rows.Clear();

            var gosterilecek_cocuklar = DatabaseManager.Instance.Cocuklar.Where(f => (f.aktif_mi == DatabaseManager.AKTIFLIK.AKTIF || devam_etmeyenleri_goster)).ToList();
            dataGridView1.Rows.Add(gosterilecek_cocuklar.Count);
            for(int i = 0; i < gosterilecek_cocuklar.Count; i++)
            {
                var cocuk = gosterilecek_cocuklar[i];

                dataGridView1.Rows[i].Cells[(int)Sutunlar.ID].Value = cocuk.id;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.AD].Value = cocuk.cocuk_adi;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.ADRES].Value = cocuk.adres;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.TC].Value = cocuk.tc_no;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.DUZEN].Value = cocuk.duzen_metin;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.AYLIK].Value = cocuk.aylik_ucret;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.AYLIK_KDVSIZ].Value = cocuk.aylik_ucret_kdvsiz;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.KESILEN_KDV].Value = cocuk.kesilen_kdv;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.SINIF].Value = cocuk.sinif.ToString().Replace("_", " ");
                dataGridView1.Rows[i].Cells[(int)Sutunlar.CINSIYET].Value = cocuk.cinsiyet.ToString();
                dataGridView1.Rows[i].Cells[(int)Sutunlar.AKTIF].Value = cocuk.aktif_mi == DatabaseManager.AKTIFLIK.AKTIF ? onayli : onaysiz;
                dataGridView1.Rows[i].Cells[(int)Sutunlar.SEC].Value = onaysiz;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool islem_bitince_yenile = false;

                var tiklanan_id = (int)dataGridView1.Rows[e.RowIndex].Cells[(int)Sutunlar.ID].Value;
                var cocuk = DatabaseManager.Instance.Cocuk_Al(tiklanan_id);
                DataGridViewTextBoxCell chk = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                switch ((Sutunlar)e.ColumnIndex)
                {
                    case Sutunlar.AD:
                        {
                            Text_Degistir dialog = new Text_Degistir();
                            dialog.sadece_sayi = false;
                            dialog.textBox_eski.Text = cocuk.cocuk_adi;
                            dialog.textBox_yeni.Text = cocuk.cocuk_adi;
                            var dialog_sonuc = dialog.ShowDialog();
                            switch (dialog_sonuc)
                            {
                                case DialogResult.OK:
                                    {
                                        cocuk.cocuk_adi = (string)dialog.deger;
                                        chk.Value = cocuk.cocuk_adi;

                                        cocuk.guncelle = true;
                                    }
                                    break;
                                case DialogResult.Cancel:
                                case DialogResult.Abort:
                                case DialogResult.Retry:
                                case DialogResult.Ignore:
                                case DialogResult.Yes:
                                case DialogResult.No:
                                case DialogResult.None:
                                default:
                                    break;
                            }
                        }
                        break;

                    case Sutunlar.ADRES:
                        {
                            Text_Degistir dialog = new Text_Degistir();
                            dialog.textBox_eski.Text = cocuk.adres.ToString();
                            dialog.textBox_yeni.Text = cocuk.adres.ToString();
                            dialog.sadece_sayi = false;
                            var dialog_sonuc = dialog.ShowDialog();
                            if (dialog_sonuc == DialogResult.OK)
                            {
                                cocuk.adres = (string)dialog.deger;
                                chk.Value = cocuk.adres.ToString();

                                cocuk.guncelle = true;
                            }
                        }
                        break;
                    case Sutunlar.TC:
                        {
                            Text_Degistir dialog = new Text_Degistir();
                            dialog.textBox_eski.Text = cocuk.tc_no.ToString();
                            dialog.textBox_yeni.Text = cocuk.tc_no.ToString();
                            dialog.sadece_sayi = true;
                            var dialog_sonuc = dialog.ShowDialog();
                            switch (dialog_sonuc)
                            {
                                case DialogResult.OK:
                                    {
                                        cocuk.tc_no = (string)dialog.deger;
                                        chk.Value = cocuk.tc_no.ToString();

                                        cocuk.guncelle = true;
                                    }
                                    break;
                                case DialogResult.Cancel:
                                case DialogResult.Abort:
                                case DialogResult.Retry:
                                case DialogResult.Ignore:
                                case DialogResult.Yes:
                                case DialogResult.No:
                                case DialogResult.None:
                                default:
                                    break;
                            }
                        }
                        break;
                    case Sutunlar.DUZEN:
                        {
                            Text_Degistir dialog = new Text_Degistir();
                            dialog.textBox_eski.Text = cocuk.duzen_metin.ToString();
                            dialog.textBox_yeni.Text = cocuk.duzen_metin.ToString();
                            dialog.sadece_sayi = false;
                            var dialog_sonuc = dialog.ShowDialog();
                            switch (dialog_sonuc)
                            {
                                case DialogResult.OK:
                                    {
                                        cocuk.duzen_metin = (string)dialog.deger;
                                        chk.Value = cocuk.duzen_metin.ToString();

                                        cocuk.guncelle = true;
                                    }
                                    break;
                                case DialogResult.Cancel:
                                case DialogResult.Abort:
                                case DialogResult.Retry:
                                case DialogResult.Ignore:
                                case DialogResult.Yes:
                                case DialogResult.No:
                                case DialogResult.None:
                                default:
                                    break;
                            }
                        }
                        break;
                    case Sutunlar.AYLIK:
                        {
                            DataGridViewTextBoxCell cell_kdv = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[(int)Sutunlar.KESILEN_KDV];
                            DataGridViewTextBoxCell cell_kdvsiz = (DataGridViewTextBoxCell)dataGridView1.Rows[e.RowIndex].Cells[(int)Sutunlar.AYLIK_KDVSIZ];

                            Text_Degistir dialog = new Text_Degistir();
                            dialog.textBox_eski.Text = cocuk.aylik_ucret.ToString();
                            dialog.textBox_yeni.Text = cocuk.aylik_ucret.ToString();
                            var dialog_sonuc = dialog.ShowDialog();
                            switch (dialog_sonuc)
                            {
                                case DialogResult.OK:
                                    {
                                        cocuk.Ucret_Hesapla(DatabaseManager.kdv, (double)dialog.deger);
                                        chk.Value = cocuk.aylik_ucret.ToString();
                                        cell_kdv.Value = cocuk.kesilen_kdv.ToString();
                                        cell_kdvsiz.Value = cocuk.aylik_ucret_kdvsiz.ToString();

                                        cocuk.guncelle = true;
                                    }
                                    break;
                                case DialogResult.Cancel:
                                case DialogResult.Abort:
                                case DialogResult.Retry:
                                case DialogResult.Ignore:
                                case DialogResult.Yes:
                                case DialogResult.No:
                                case DialogResult.None:
                                default:
                                    break;
                            }
                        }
                        break;
                    case Sutunlar.SINIF:
                        {
                            DatabaseManager.SINIFLAR atanacak_sinif;
                            switch ((string)chk.Value)
                            {
                                case "SIFIR IKI": atanacak_sinif = DatabaseManager.SINIFLAR.UC; break;
                                case "UC": atanacak_sinif = DatabaseManager.SINIFLAR.DORT; break;
                                case "DORT": atanacak_sinif = DatabaseManager.SINIFLAR.BES_ALTI; break;
                                case "BES ALTI": atanacak_sinif = DatabaseManager.SINIFLAR.SIFIR_IKI; break;
                                default: atanacak_sinif = DatabaseManager.SINIFLAR.UC; break;
                            }
                            cocuk.sinif = atanacak_sinif;
                            chk.Value = cocuk.sinif.ToString().Replace("_", " ");

                            cocuk.guncelle = true;
                        }
                        break;
                    case Sutunlar.CINSIYET:
                        {
                            if (DatabaseManager.CINSIYET.ERKEK.ToString().Equals((string)chk.Value))
                            {
                                cocuk.cinsiyet = DatabaseManager.CINSIYET.KIZ;
                            }
                            else
                            {
                                cocuk.cinsiyet = DatabaseManager.CINSIYET.ERKEK;
                            }
                            chk.Value = cocuk.cinsiyet.ToString();

                            cocuk.guncelle = true;
                        }
                        break;
                    case Sutunlar.AKTIF:
                        {
                            if (onayli.Equals((string)chk.Value))
                            {
                                chk.Value = onaysiz;
                                cocuk.aktif_mi = DatabaseManager.AKTIFLIK.PASIF;
                            }
                            else
                            {
                                chk.Value = onayli;
                                cocuk.aktif_mi = DatabaseManager.AKTIFLIK.AKTIF;
                            }

                            cocuk.guncelle = true;

                            islem_bitince_yenile = true;
                        }
                        break;
                    case Sutunlar.SEC:
                        {
                            if (onayli.Equals((string)chk.Value))
                            {
                                chk.Value = onaysiz;
                            }
                            else
                            {
                                chk.Value = onayli;
                            }
                        }
                        break;
                    case Sutunlar.AYLIK_KDVSIZ:
                    case Sutunlar.KESILEN_KDV:
                    case Sutunlar.ID:
                    default:
                        break;
                }

                DatabaseManager.Instance.Cocuklari_Kaydet();

                if (islem_bitince_yenile)
                {
                    Yenile();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button_tamamlandi_Click(object sender, EventArgs e)
        {
            cocuklar.Clear();
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var tiklanan_id = (int)dataGridView1.Rows[i].Cells[0].Value;
                var cocuk = DatabaseManager.Instance.Cocuk_Al(tiklanan_id);

                DataGridViewTextBoxCell chk = (DataGridViewTextBoxCell)dataGridView1.Rows[i].Cells[(int)Sutunlar.SEC];
                if (onayli.Equals((string)chk.Value))
                {
                    cocuklar.Add(cocuk);
                }
            }

            this.Hide();
            Ekran_Kapandi?.Invoke();
        }

        private void button_cocuk_ekle_Click(object sender, EventArgs e)
        {
            Cocuk_Ekle_Form dialog = new Cocuk_Ekle_Form();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.yeni_cocuk.DBye_Ekle();
                Yenile();
            }
        }

        private void checkBox_devam_goster_CheckedChanged(object sender, EventArgs e)
        {
            devam_etmeyenleri_goster = checkBox_devam_goster.Checked;
            Yenile();
        }
    }
}