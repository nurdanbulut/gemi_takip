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
    public partial class GezginGemi : Form
    {
        public GezginGemi()
        {
            InitializeComponent();
        }
        Kaptan kaptan = new Kaptan();
        Liman liman = new Liman();
        Mücret mücret = new Mücret();
        Sefer sefer = new Sefer();
        Gemi gemi = new Gemi();
        //formlar arası geçiş
        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gemi.Show();
        }

        private void kaptanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kaptan.Show();
        }

        private void limanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            liman.Show();
        }

        private void seferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sefer.Show();
        }

        private void mücretToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mücret.Show();
        }
    }
}
