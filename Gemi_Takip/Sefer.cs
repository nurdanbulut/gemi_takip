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
    public partial class Sefer : Form
    {
        public Sefer()
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
            da = new SqlDataAdapter("SELECT *FROM Seferler", baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }
        //listeleme yapılıyor
        private void btnlistele_Click(object sender, EventArgs e)
        {
            DataShow();
            toolStripStatusLabel1.Text = "Seferler  Listeleniyor !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //ekleme işlemi yapılıyor
        private void btnekle_Click(object sender, EventArgs e)
        {
            string sorgu1 = "INSERT INTO Seferler(GemiSeriNo,Kaptan1ID,Kaptan2ID,MurettebatID,YolcuGirisTarihi,DonusTarihi,KalkisLimanı) VALUES (@GemiSeriNo,@Kaptan1ID,@Kaptan2ID,@MurettebatID,@YolcuGirisTarihi,@DonusTarihi,@KalkisLimanı)";
            command = new SqlCommand(sorgu1, baglanti);
            command.Parameters.AddWithValue("@GemiSeriNo", txtGemiseri.Text);
            command.Parameters.AddWithValue("@Kaptan1ID", txtKaptan1id.Text);
            command.Parameters.AddWithValue("@Kaptan2ID", txtKaptan2id.Text);
            command.Parameters.AddWithValue("@MurettebatID", txtMurettabatid.Text);
            command.Parameters.AddWithValue("@YolcuGirisTarihi", dtpGiris.Value);
            command.Parameters.AddWithValue("@DonusTarihi", dtpDonus.Value);
            command.Parameters.AddWithValue("@KalkisLimanı", txtLiman.Text);
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            toolStripStatusLabel1.Text = "Sefer Başarılı Bir Şekilde Eklendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //güncelleme işlemi yapılıyor
        private void btndüzenle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Seferler SET GemiSeriNo = @GemiSeriNo,Kaptan1ID = @Kaptan1ID,Kaptan2ID = @Kaptan2ID,MurettebatID = @MurettebatID,YolcuGirisTarihi=@YolcuGirisTarihi,DonusTarihi = @DonusTarihi,KalkisLimanı=@KalkisLimanı WHERE ID = @ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            command.Parameters.AddWithValue("@GemiSeriNo", txtGemiseri.Text);
            command.Parameters.AddWithValue("@Kaptan1ID", txtKaptan1id.Text);
            command.Parameters.AddWithValue("@Kaptan2ID", txtKaptan2id.Text);
            command.Parameters.AddWithValue("@MurettebatID", txtMurettabatid.Text);
            command.Parameters.AddWithValue("@YolcuGirisTarihi", dtpGiris.Value);
            command.Parameters.AddWithValue("@DonusTarihi", dtpDonus.Value);
            command.Parameters.AddWithValue("@KalkisLimanı", txtLiman.Text);

            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Sefer Başarılı Bir Şekilde Güncellendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }
        //silme işlemi yapılıyor
        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Seferler WHERE ID=@ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel1.Text = "Sefer Başarılı Bir Şekilde Silindi !";
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
            txtGemiseri.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtKaptan1id.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtKaptan2id.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMurettabatid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtpGiris.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtpDonus.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtLiman.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
