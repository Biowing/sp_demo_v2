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
            connetionString = "server=localhost; database =sakila;uid=root;pwd=root;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                //tüm tablonun çekilmesi komutu
                string kayit = "SELECT actor_id AS 'ID', CONCAT(first_name ,' ',last_name) AS 'AD SOYAD' ,last_update AS 'SON GÜNCELLEME'  from actor";
                MySqlCommand komut = new MySqlCommand(kayit, cnn);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
               
                //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
                DataTable dt = new DataTable();
                
                da.Fill(dt);
                
                //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
                dataGridView1.DataSource = dt;
                //tabloya her bir satır için buton ekleme
                DataGridViewButtonColumn buton = new DataGridViewButtonColumn();
                buton.HeaderText = "Düzenle?";
                buton.Text = "Düzenle";
                buton.UseColumnTextForButtonValue = true;
                buton.DataPropertyName = "last_update";
                dataGridView1.Columns.Add(buton);
                //buton ekleme sonu
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex);
            }

        }
        //tablodaki butona tıklandığında yapılacaklar
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string val = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // butona tıklandığında aynı satırda bulundığı kayıtın herhangi bir verisine erişmek için kullanılabilir
                MessageBox.Show("Seçtiğiniz kişinin adı " + val );
            }

        }
    }
}
