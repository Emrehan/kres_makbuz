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
    public partial class Text_Degistir : Form
    {
        public object deger;
        public bool sadece_sayi = true;
        public Text_Degistir()
        {
            InitializeComponent();
        }

        private void button_onayla_Click(object sender, EventArgs e)
        {

        }

        private void textBox_yeni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sadece_sayi)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox_yeni_TextChanged(object sender, EventArgs e)
        {
            if (sadece_sayi)
            {
                double.TryParse(textBox_yeni.Text, out double sonuc);
                deger = sonuc;
            }
            else
            {
                deger = textBox_yeni.Text;
            }
        }
    }
}
