using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParcialGrupoDEV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openNorthwindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form1Northwind();
            f.Show();
        }

        private void openPubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form2Pubs();
            f.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenNorthwind_Click(object sender, EventArgs e)
        {
            var f = new Form1Northwind();
            f.Show();
        }

        private void btnOpenPubs_Click(object sender, EventArgs e)
        {
            var f = new Form2Pubs();
            f.Show();
        }
    }
}
