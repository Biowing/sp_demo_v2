using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class veritabani : Form
    {
        public veritabani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Veritabanı Bağlantısı ************************

            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=remotemysql.com; database =tDNQ1XRXlu;uid=tDNQ1XRXlu;pwd=F44eHROJZ1;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                //tüm tablonun çekilmesi komutu
                //string kayit = "SELECT * from actor";
                //MySqlCommand komut = new MySqlCommand(kayit, cnn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.

                //MySqlDataAdapter da = new MySqlDataAdapter(komut);
                //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                //dataGridView1.DataSource = dt;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

        }
    }
}
