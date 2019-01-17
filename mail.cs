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
    public partial class mail : Form
    {
        public mail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Net.Mail.MailMessage mesaj =new System.Net.Mail.MailMessage(); //mesaj adında mail class'ı oluşturuyoruz.
            mesaj.To.Add("omrdrmz1221@hotmail.com"); //mail gönderilecek e postaları yazıyoruz
                                                     //!! veritabanından çekilen birden çok mail adresine göndermeyi araştır !!
                                                     //mesaj.Attachments.Add(new Attachment(@"C:\deneme.txt")); // uygulamada pdf olarak takvim gönderilmek istendiğinde işine yarayacak!
            mesaj.Subject = "Deneme 1"; //mail konusu
            mesaj.From = new System.Net.Mail.MailAddress("omrfrkdrmz@gmail.com","Ömer Durmaz"); //E postanın klmden gönderileceğini yazıyoruz.
            mesaj.Body = "İçerik"; // Mail İçeriği

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587); //smtp class ına giderek sunucu ile bağlanıyoruz.
            smtp.EnableSsl = true; //ssl güvenliğini aktifleştiriyoruz
            smtp.Credentials = new System.Net.NetworkCredential("omrfrkdrmz@gmail.com", "0536kutu78"); // mail gönderen mesaj adresinin bilgilerini yazıyoruz


            try
            {
                smtp.Send(mesaj);
                MessageBox.Show("Mail Başarıyla Gönderildi!");
            }
            catch (Exception err)
            {
                MessageBox.Show("Hata! " + err.Message); // eğer başarısız olursa hatayı ekrana yazdırıyoruz
            }
        }
    }
}
