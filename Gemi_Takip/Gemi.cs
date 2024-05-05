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
    public partial class Gemi : Form
    {
        public Gemi()
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
            da = new SqlDataAdapter("SELECT *FROM Gemiler", baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }
        //listeleme yapılıyor
        private void btnlistele_Click(object sender, EventArgs e)
        {
            DataShow();
            toolStripStatusLabel3.Text = "Gemiler  Listeleniyor !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //ekleme işlemi yapılıyor
        private void btnekle_Click(object sender, EventArgs e)
        {
            string sorgu1 = "INSERT INTO Gemiler(Ad,Agirlik,YapimYili,Tip,Kapasite,MaxAgirlik,PetrolKapasitesi,KonteynerKapasitesi) VALUES (@Ad,@Agirlik,@YapimYili,@Tip,@Kapasite,@MaxAgirlik,@PetrolKapasitesi,@KonteynerKapasitesi)";
            command = new SqlCommand(sorgu1, baglanti);
            command.Parameters.AddWithValue("@Ad", txtAd.Text);
            command.Parameters.AddWithValue("@Agirlik", Convert.ToDecimal(txtAgirlik.Text));
            command.Parameters.AddWithValue("@YapimYili", Convert.ToInt32(txtYapim.Text));
            command.Parameters.AddWithValue("@Tip", txtTip.Text);
            command.Parameters.AddWithValue("@Kapasite", txtKapasite.Text);
            command.Parameters.AddWithValue("@MaxAgirlik", Convert.ToDecimal(txtMax.Text));
            command.Parameters.AddWithValue("@PetrolKapasitesi", Convert.ToDecimal(txtPetrol.Text));
            command.Parameters.AddWithValue("@KonteynerKapasitesi", Convert.ToInt32(txtKonteyner.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            toolStripStatusLabel3.Text = "Gemi Başarılı Bir Şekilde Eklendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //güncelleme işlemi yapılıyor
        private void btndüzenle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Gemiler SET Ad = @Ad,Agirlik = @Agirlik,YapimYili = @YapimYili,Tip = @Tip,Kapasite=@Kapasite,MaxAgirlik = @MaxAgirlik,PetrolKapasitesi=@PetrolKapasitesi,KonteynerKapasitesi = @KonteynerKapasitesi  WHERE SeriNo = @SeriNo";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@SeriNo", Convert.ToInt32(txtSeri.Text));
            command.Parameters.AddWithValue("@Ad", txtAd.Text);
            command.Parameters.AddWithValue("@Agirlik", Convert.ToDecimal(txtAgirlik.Text));
            command.Parameters.AddWithValue("@YapimYili", Convert.ToInt32(txtYapim.Text));
            command.Parameters.AddWithValue("@Tip", txtTip.Text);
            command.Parameters.AddWithValue("@Kapasite", txtKapasite.Text);
            command.Parameters.AddWithValue("@MaxAgirlik", Convert.ToDecimal(txtMax.Text));
            command.Parameters.AddWithValue("@PetrolKapasitesi", Convert.ToDecimal(txtPetrol.Text));
            command.Parameters.AddWithValue("@KonteynerKapasitesi", Convert.ToInt32(txtKonteyner.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel3.Text = "Gemi Başarılı Bir Şekilde Güncellendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //silme işlemi yapılıyor
        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Gemiler WHERE SeriNo=@SeriNo";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@SeriNo", Convert.ToInt32(txtSeri.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel3.Text = "Gemi Başarılı Bir Şekilde Silindi !";
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
            toolStripStatusLabel3.Text = "Bütün Yazılar Temizlendi ! ";
        }
        //datagridviewda listelenirken konumlandırma yapılıyor
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtSeri.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtAgirlik.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtYapim.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTip.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtKapasite.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtMax.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtPetrol.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtKonteyner.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
