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
    public partial class Mücret : Form
    {
        public Mücret()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=NURDAN\\SQLEXPRESS;Initial Catalog=GemiDB;Integrated Security=SSPI");
        SqlCommand command;
        SqlDataAdapter da;

        void DataShow()
        {
            SqlConnection baglanti = new SqlConnection("server=NURDAN\\SQLEXPRESS;Initial Catalog=GemiDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM Murettebat", baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }
        //listeleme yapılıyor
        private void btnlistele_Click(object sender, EventArgs e)
        {
            DataShow();
            toolStripStatusLabel1.Text = "Mürettebat  Listeleniyor !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //ekleme işlemi yapılıyor
        private void btnekle_Click(object sender, EventArgs e)
        {
            string sorgu1 = "INSERT INTO Murettebat(Ad,Soyad,Adres,Vatandaslik,DogumTarihi,IseGirisTarihi,Gorev) VALUES (@Ad,@Soyad,@Adres,@Vatandaslik,@DogumTarihi,@IseGirisTarihi,@Gorev)";
            command = new SqlCommand(sorgu1, baglanti);
            command.Parameters.AddWithValue("@Ad", txtAd.Text);
            command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            command.Parameters.AddWithValue("@Adres", txtAdres.Text);
            command.Parameters.AddWithValue("@Vatandaslik", txtVatandas.Text);
            command.Parameters.AddWithValue("@DogumTarihi", dtpDogum.Value);
            command.Parameters.AddWithValue("@IseGirisTarihi", dtpGiris.Value);
            command.Parameters.AddWithValue("@Gorev", txtGorev.Text);
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            toolStripStatusLabel1.Text = "Mürettebat Başarılı Bir Şekilde Eklendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //güncelleme işlemi yapılıyor
        private void btndüzenle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Murettebat SET Ad = @Ad,Soyad = @Soyad,Adres = @Adres,Vatandaslik = @Vatandaslik,DogumTarihi=@DogumTarihi,IseGirisTarihi = @IseGirisTarihi,Gorev=@Gorev WHERE ID = @ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            command.Parameters.AddWithValue("@Ad", txtAd.Text);
            command.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            command.Parameters.AddWithValue("@Adres", txtAdres.Text);
            command.Parameters.AddWithValue("@Vatandaslik", txtVatandas.Text);
            command.Parameters.AddWithValue("@DogumTarihi", dtpDogum.Value);
            command.Parameters.AddWithValue("@IseGirisTarihi", dtpGiris.Value);
            command.Parameters.AddWithValue("@Gorev", txtGorev.Text);

            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Mürettebat Başarılı Bir Şekilde Güncellendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //silme işlemi yapılıyor
        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Murettebat WHERE ID=@ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Mürettebat Başarılı Bir Şekilde Silindi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //formdaki tool temizlemesi yapılıyor
        private void btntemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is RichTextBox)
                {
                    item.Text = "";
                }
                if (item is DateTimePicker)
                {
                    item.ResetText();
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is NumericUpDown)
                {
                    item.Text = "";
                }
            }
            toolStripStatusLabel1.Text = "Bütün Yazılar Temizlendi ! ";
        }
        //datagridviewda listelenirken konumlandırma yapılıyor
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtVatandas.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtpDogum.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtpGiris.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtGorev.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
