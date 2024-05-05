using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gemi_Takip
{
    public partial class Kullanici : Form
    {
        public Kullanici()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=NURDAN\SQLEXPRESS;Initial Catalog=GemiDB;Integrated Security=True");
        //rastgele sayı üretimi
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            long rndnumber = rnd.Next(1000, 9999);
            lblrandom.Text = rndnumber.ToString();
        }
        //kullanıcı adı,şifre ve doğrulama sayısı aynı ise giriş yapıyor yoksa uyarı veriyor 
        private void btnsignin_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "Select * From Kullanıcılar where Username=@usernames AND Password=@passwords";
            SqlParameter prm1 = new SqlParameter("usernames", txtkullanici.Text.Trim());
            SqlParameter prm2 = new SqlParameter("passwords", txtsifre.Text.Trim());
            SqlCommand command = new SqlCommand(sql, baglanti);
            command.Parameters.Add(prm1);
            command.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            baglanti.Close();

            if (dt.Rows.Count > 0)
            {
                if (lblrandom.Text == txtdogrulama.Text)
                {
                    toolStripStatusLabel1.Text = "Kayıt işlemi başarı ile gerçekleşti";
                    statusStrip1.Refresh();
                    Application.DoEvents();
                    GezginGemi gezgin = new GezginGemi();
                    gezgin.Show();
                    Close();
                    
                }
                else
                {
                    toolStripStatusLabel1.Text = "Doğrulama Kodunu Kontrol Ediniz ! ";
                    statusStrip1.Refresh();
                    Application.DoEvents();
                }
            }

            else if (lblrandom.Text != txtdogrulama.Text && dt.Rows.Count == 0)
            {
                toolStripStatusLabel1.Text = "Bilgilerinizi Kontrol Edip Tekrar Deneyiniz ! ";
                statusStrip1.Refresh();
                Application.DoEvents();
            }

            else
            {
                toolStripStatusLabel1.Text = "Kullanıcı Adı veya Şifrenizi Kontrol Ediniz ! ";
                statusStrip1.Refresh();
                Application.DoEvents();
            }
        }
        //arkaplan rengi transparan olmasını sağlıyor 
        private void Kullanici_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
