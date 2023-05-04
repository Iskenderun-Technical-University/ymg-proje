using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp5
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            ÜyeEkle üyeEkle = new ÜyeEkle();
            üyeEkle.Show();
            this.Hide();


        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            GuncelleSil guncelleSil = new GuncelleSil();
            guncelleSil.Show();
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Odemeler odemeler = new Odemeler();
            odemeler.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
