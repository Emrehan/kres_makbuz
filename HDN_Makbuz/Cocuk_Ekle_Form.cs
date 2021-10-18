using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDN_Makbuz
{
    public partial class Cocuk_Ekle_Form : Form
    {
        public Cocuk_Bilgileri yeni_cocuk;
        private DatabaseManager.SINIFLAR sinif = DatabaseManager.SINIFLAR.SIFIR_IKI;
        private DatabaseManager.CINSIYET cinsiyet = DatabaseManager.CINSIYET.ERKEK;

        public Cocuk_Ekle_Form()
        {
            InitializeComponent();

            button_sinif.Text = sinif.ToString().Replace('_', ' ');
            button_cinsiyet.Text = cinsiyet.ToString();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            yeni_cocuk = new Cocuk_Bilgileri(
                                                -1,
                                                textBox_isim.Text,
                                                richTextBox_adres.Text,
                                                textBox_tc.Text,
                                                textBox_gelme.Text,
                                                (double)numericUpDown_aylik.Value,
                                                sinif,
                                                cinsiyet,
                                                DatabaseManager.AKTIFLIK.AKTIF
                                            );
        }

        private void button_sinif_Click(object sender, EventArgs e)
        {
            switch (sinif)
            {
                case DatabaseManager.SINIFLAR.SIFIR_IKI:
                    {
                        sinif = DatabaseManager.SINIFLAR.UC;
                    }
                    break;
                case DatabaseManager.SINIFLAR.UC:
                    {
                        sinif = DatabaseManager.SINIFLAR.DORT;
                    }
                    break;
                case DatabaseManager.SINIFLAR.DORT:
                    {
                        sinif = DatabaseManager.SINIFLAR.BES_ALTI;
                    }
                    break;
                case DatabaseManager.SINIFLAR.BES_ALTI:
                    {
                        sinif = DatabaseManager.SINIFLAR.SIFIR_IKI;
                    }
                    break;
                default:
                    break;
            }

            button_sinif.Text = sinif.ToString().Replace('_', ' ');
        }

        private void button_cinsiyet_Click(object sender, EventArgs e)
        {
            switch (cinsiyet)
            {
                case DatabaseManager.CINSIYET.ERKEK:
                    {
                        cinsiyet = DatabaseManager.CINSIYET.KIZ;
                    }
                    break;
                case DatabaseManager.CINSIYET.KIZ:
                    {
                        cinsiyet = DatabaseManager.CINSIYET.ERKEK;
                    }
                    break;
                default:
                    break;
            }

            button_cinsiyet.Text = cinsiyet.ToString();
        }
    }
}
