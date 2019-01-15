using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string deger { get; set; }
        public Form1()
        {            InitializeComponent();
        }
        //KAPATMA BUTONU
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        //KÜÇÜLTME BUTONU
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //ŞİFREYİ GÖSTER GİZLE BUTONU
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar==true)
            {
                textBox2.UseSystemPasswordChar = false;
                button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.openeye));
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closedeye));
            }
        }
        //GİRİŞ BUTONU
        private void button5_Click(object sender, EventArgs e)
        {
            //Eposta kontrolü ve girilen eposta uygunsa ana forma giriş yapıldı gönderiyor
            Regex duzenliifade;
            if (textBox1.Text.Trim()!=string.Empty)
            {
                duzenliifade = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!duzenliifade.IsMatch(textBox1.Text.Trim()))
                {
                    MessageBox.Show("Yanlış eposta !");
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                else
                {
                    this.deger = "girildi";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }
    }
}
