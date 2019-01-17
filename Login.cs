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
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{

    public partial class Login : Form
    {
        public string deger { get; set; }
        public Login()
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
            if (txtsifre.UseSystemPasswordChar==true)
            {
                button2.BackColor = Color.FromArgb(44,171,227);
                txtsifre.UseSystemPasswordChar = false;
                button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.openeye));
            }
            else
            {
                button2.BackColor = Color.FromArgb(255,80,80);

                txtsifre.UseSystemPasswordChar = true;
                button2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.closedeye));
            }
        }
        //GİRİŞ BUTONU
        private void button5_Click(object sender, EventArgs e)
        {
            string eposta="admin@hotmail.com";
            string sifre="root";
            //Eposta kontrolü ve girilen eposta uygunsa ana forma giriş yapıldı gönderiyor
            Regex duzenliifade;
            if (txtkod.Text=="" || txteposta.Text==""||txtsifre.Text=="")
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!");
            }else if (txteposta.Text.Trim()!=string.Empty)
            {
                duzenliifade = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!duzenliifade.IsMatch(txteposta.Text.Trim()))
                {
                    MessageBox.Show("Hatalı E posta Girişi Yaptınız!");
                    txteposta.Focus();
                    txteposta.SelectAll();
                }
                else
                {
                    if (txteposta.Text==eposta && txtsifre.Text==sifre && txtkod.Text==lblkod.Text)
                    {
                        this.deger = "girildi";
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Girilen Bilgiler Hatalı!");
                    }
                   
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Güvenlik Kodu
            int rsayi;
            Random r = new Random();
            rsayi = r.Next(100000, 999999);
            lblkod.Text = rsayi.ToString();
        }
        //Şifremi Unuttum
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        //Güvenlik Kodu sadece sayı girişi
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
