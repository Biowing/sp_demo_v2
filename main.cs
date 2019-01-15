using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        
        private void main_Load(object sender, EventArgs e)
        {
            //sayfa yüklendiğinde giris ekranına gidiyor ve kullanıcı girişine göre na programı gösteriyor ya da kapatıyor

            Form1 form1 = new Form1();
            var cevap = form1.ShowDialog();
            if (cevap==DialogResult.OK)
            {
                label1.Text = form1.deger;
            }
            else
            {
                this.Close();
            }
          
        }
    }
}
