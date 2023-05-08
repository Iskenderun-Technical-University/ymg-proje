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
using System.Data.SqlClient;
using System.Windows.Input;

namespace WindowsFormsApp5
{
    public partial class GuncelleSil : Form
    {
        public GuncelleSil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OUESDKU\SQLEXPRESS01;Initial Catalog=SporDB;Integrated Security=True;Pooling=False");

        private void uyeler()
        {
            baglanti.Close();
            string query = "select*from UyeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            UyeDGV.DataSource = ds.Tables[0];
            baglanti.Close();

           

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GuncelleSil_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        int key = 0;
        private void UyeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(UyeDGV.SelectedRows[0].Cells[0].Value.ToString());

            
            AdSoyadTb.Text = UyeDGV.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTb.Text = UyeDGV.SelectedRows[0].Cells[2].Value.ToString();
            CinsiyetCb.Text = UyeDGV.SelectedRows[0].Cells[3].Value.ToString();
            YasTb.Text = UyeDGV.SelectedRows[0].Cells[4].Value.ToString();
            OdemeTb.Text = UyeDGV.SelectedRows[0].Cells[5].Value.ToString();
            ZamanlamaCb.Text = UyeDGV.SelectedRows[0].Cells[6].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            CinsiyetCb.Text = "";
            YasTb.Text = "";
            OdemeTb.Text = "";
            ZamanlamaCb.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz");

            }
            else
            {
                try
                {

                    baglanti.Open();
                    string query = "delete from UyeTbl where UyeId="+key+";";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Silindi");
                    baglanti.Close();
                    uyeler();
                }
                catch(Exception Ex) {
                    MessageBox.Show(Ex.Message);
                        }
                baglanti.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0 ||AdSoyadTb.Text==""||TelefonTb.Text==""||CinsiyetCb.Text==""||YasTb.Text==""||OdemeTb.Text==""||ZamanlamaCb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");

            }
            else
            {
                try
                {

                    baglanti.Open();
                    string query = "update UyeTbl set UAdSOyad='" + AdSoyadTb.Text + "',UTelefon='" + TelefonTb.Text + "',UCinsiyet='" + CinsiyetCb.Text + "',UYas='" + YasTb.Text + "',UOdeme='" + OdemeTb.Text + "',UZamanlama='" + ZamanlamaCb.Text + "' where UId=" + key + ";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Guncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
