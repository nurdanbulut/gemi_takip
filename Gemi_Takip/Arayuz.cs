using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gemi_Takip
{
    public partial class Arayuz : Form
    {
        public Arayuz()
        {
            InitializeComponent();
        }
        Kullanici kullanici = new Kullanici();
        DialogResult dialog = new DialogResult();
        //Kullanıcı Girişi Formuna Geçiş
        private void girişYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanici.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Çıkış Yapmak Üzeresiniz.\nÇıkış Yapmak İstediğinizden Emin Misiniz ?", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {

                Application.Exit();

            }
        }
    }
}
