using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace NesneProjeÖdevim
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış İşlemi", MessageBoxButtons.YesNo);
            if(onay==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
           
        {
            try
            {
                OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
                Veritabani_Baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select Adi,Sifre from Müşteri_Bilgileri where Adi=@adı and Sifre=@sifre", Veritabani_Baglanti);
                sorgu.Parameters.AddWithValue("@Adi", textBox2.Text);
                sorgu.Parameters.AddWithValue("@Sifre", textBox3.Text);
                OleDbDataReader dr;
                dr = sorgu.ExecuteReader();
                if (dr.Read())
                {
                    if (gkod == Convert.ToInt16(textBox4.Text))
                    {
                        Form2 frm = new Form2();
                        frm.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Güvenlik Kodunu Yanlış Girdiniz. Lütfen Doğru Giriş Yapınız.");
                    }
                }
                else
                {
                    Veritabani_Baglanti.Close();
                    MessageBox.Show("Hatalı Kullanıcı Adı Veya Parola. Lütfen tekrar deneyiniz.");
                }
            }
            catch
            {
                MessageBox.Show("Lütfen Kullanıcı Adı Ve Şifreniz İle Giriş Yapınız.");
            }
            finally
            {
                textBox2.Text = "";
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Clear();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış İşlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        int gkod;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            gkod = r.Next(1000, 9999);
            label4.Text = gkod.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
