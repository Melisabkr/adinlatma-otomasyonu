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
    public partial class Form2 : Form
    {
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
        OleDbDataAdapter Veri_Adaptor;
        OleDbCommand Veri_Komutu;
        OleDbDataReader Veri_Oku;
        DataSet Veri_Seti;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[3].Value.ToString();
             textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
             textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
             textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
             textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_Bilgileri");
            dataGridView1.DataSource = Veri_Seti.Tables["Müşteri_Bilgileri"];
            Veritabani_Baglanti.Close();
            Veri_Adaptor = new OleDbDataAdapter("Select * from Aydınlatma_Çeşitleri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Aydınlatma_Çeşitleri");
            dataGridView2.DataSource = Veri_Seti.Tables["Aydınlatma_Çeşitleri"];
            Veritabani_Baglanti.Close();
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_İletişim_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_İletişim_Bilgileri");
            dataGridView3.DataSource = Veri_Seti.Tables["Müşteri_İletişim_Bilgileri"];
            Veritabani_Baglanti.Close();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox2.ImageLocation = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Ürününüz adresinize teslim edilecektir. Güle güle kullanın :)");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz?", "Çıkış İşlemi", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
            Veritabani_Baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Müşteri_Bilgileri(Adi,Soyadi,Sifre) values (@Adi,@Soyadi,@Sifre)", Veritabani_Baglanti);
            komut.Parameters.AddWithValue("@Adi", textBox1.Text);
            komut.Parameters.AddWithValue("@Soyadi", textBox3.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox4.Text);
            komut.ExecuteReader();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı...");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_Bilgileri");
            dataGridView1.DataSource = Veri_Seti.Tables["Müşteri_Bilgileri"];
            Veritabani_Baglanti.Close();
            Veritabani_Baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("insert into Müşteri_İletişim_Bilgileri(Telefon_No,Adres) values (@Telefon_No,@Adres)", Veritabani_Baglanti);
            komut1.Parameters.AddWithValue("@Telefon_No", textBox5.Text);
            komut1.Parameters.AddWithValue("@Adres", textBox6.Text);
            komut1.ExecuteReader();
            Veritabani_Baglanti.Close();
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_İletişim_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_İletişim_Bilgileri");
            dataGridView3.DataSource = Veri_Seti.Tables["Müşteri_İletişim_Bilgileri"];
            Veritabani_Baglanti.Close();



        }
        string secili_kayit;
        bool kontrol = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            secili_kayit = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            kontrol = true;
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            {
                if(kontrol == true)
                {
                    OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
                    Veritabani_Baglanti.Open();
                    OleDbCommand sil = new OleDbCommand("delete from Müşteri_Bilgileri where kimlik=@kimlik", Veritabani_Baglanti);
                    sil.Parameters.AddWithValue("@kimlik", secili_kayit);
                    sil.ExecuteNonQuery();
                    Veritabani_Baglanti.Close();
                    Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_Bilgileri", Veritabani_Baglanti);
                    Veri_Seti = new DataSet();
                    Veritabani_Baglanti.Open();
                    Veri_Adaptor.Fill(Veri_Seti, "Müşteri_Bilgileri");
                    dataGridView1.DataSource = Veri_Seti.Tables["Müşteri_Bilgileri"];
                    Veritabani_Baglanti.Close();
                    
                }
                
                if (kontrol1 == true)
                {
                    OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
                    Veritabani_Baglanti.Open();
                    OleDbCommand sil1 = new OleDbCommand("delete from Müşteri_İletişim_Bilgileri where kimlik=@kimlik", Veritabani_Baglanti);
                    sil1.Parameters.AddWithValue("@kimlik", secili1_kayit);
                    sil1.ExecuteNonQuery();
                    Veritabani_Baglanti.Close();
                    Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_İletişim_Bilgileri", Veritabani_Baglanti);
                    Veri_Seti = new DataSet();
                    Veritabani_Baglanti.Open();
                    Veri_Adaptor.Fill(Veri_Seti, "Müşteri_İletişim_Bilgileri");
                    dataGridView3.DataSource = Veri_Seti.Tables["Müşteri_İletişim_Bilgileri"];
                    Veritabani_Baglanti.Close();
                    
                }
                
            }




        }
        string secili1_kayit;
        bool kontrol1 = false;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili1 = dataGridView3.SelectedCells[0].RowIndex;
            secili1_kayit = dataGridView3.Rows[secili1].Cells[0].Value.ToString();
            kontrol1 = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Update Müşteri_Bilgileri set Adi='" + textBox1.Text + "',Soyadi='" + textBox3.Text + "',Sifre='" + textBox4.Text + "'where Kimlik=" + Convert.ToInt32(textBox7.Text) + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_Bilgileri");
            dataGridView1.DataSource = Veri_Seti.Tables["Müşteri_Bilgileri"];
            Veritabani_Baglanti.Close();

            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "Update Müşteri_İletişim_Bilgileri set Telefon_No='" + textBox5.Text + "',Adres='" + textBox6.Text + "'where Kimlik=" + Convert.ToInt32(textBox8.Text) + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Düzenleme işlemi yapılmıştır.");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_İletişim_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_İletişim_Bilgileri");
            dataGridView3.DataSource = Veri_Seti.Tables["Müşteri_İletişim_Bilgileri"];
            Veritabani_Baglanti.Close();






        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void veriEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
            Veritabani_Baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Müşteri_Bilgileri(Adi,Soyadi,Sifre) values (@Adi,@Soyadi,@Sifre)", Veritabani_Baglanti);
            komut.Parameters.AddWithValue("@Adi", textBox1.Text);
            komut.Parameters.AddWithValue("@Soyadi", textBox3.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox4.Text);
            komut.ExecuteReader();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı...");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_Bilgileri");
            dataGridView1.DataSource = Veri_Seti.Tables["Müşteri_Bilgileri"];
            Veritabani_Baglanti.Close();
            Veritabani_Baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("insert into Müşteri_İletişim_Bilgileri(Telefon_No,Adres) values (@Telefon_No,@Adres)", Veritabani_Baglanti);
            komut1.Parameters.AddWithValue("@Telefon_No", textBox5.Text);
            komut1.Parameters.AddWithValue("@Adres", textBox6.Text);
            komut1.ExecuteReader();
            Veritabani_Baglanti.Close();
            Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_İletişim_Bilgileri", Veritabani_Baglanti);
            Veri_Seti = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(Veri_Seti, "Müşteri_İletişim_Bilgileri");
            dataGridView3.DataSource = Veri_Seti.Tables["Müşteri_İletişim_Bilgileri"];
            Veritabani_Baglanti.Close();
        }

        private void veriSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kontrol == true)
            {
                OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
                Veritabani_Baglanti.Open();
                OleDbCommand sil = new OleDbCommand("delete from Müşteri_Bilgileri where kimlik=@kimlik", Veritabani_Baglanti);
                sil.Parameters.AddWithValue("@kimlik", secili_kayit);
                sil.ExecuteNonQuery();
                Veritabani_Baglanti.Close();
                Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_Bilgileri", Veritabani_Baglanti);
                Veri_Seti = new DataSet();
                Veritabani_Baglanti.Open();
                Veri_Adaptor.Fill(Veri_Seti, "Müşteri_Bilgileri");
                dataGridView1.DataSource = Veri_Seti.Tables["Müşteri_Bilgileri"];
                Veritabani_Baglanti.Close();

            }

            if (kontrol1 == true)
            {
                OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data source=veritabaniyeni1.accdb");
                Veritabani_Baglanti.Open();
                OleDbCommand sil1 = new OleDbCommand("delete from Müşteri_İletişim_Bilgileri where kimlik=@kimlik", Veritabani_Baglanti);
                sil1.Parameters.AddWithValue("@kimlik", secili1_kayit);
                sil1.ExecuteNonQuery();
                Veritabani_Baglanti.Close();
                Veri_Adaptor = new OleDbDataAdapter("Select * from Müşteri_İletişim_Bilgileri", Veritabani_Baglanti);
                Veri_Seti = new DataSet();
                Veritabani_Baglanti.Open();
                Veri_Adaptor.Fill(Veri_Seti, "Müşteri_İletişim_Bilgileri");
                dataGridView3.DataSource = Veri_Seti.Tables["Müşteri_İletişim_Bilgileri"];
                Veritabani_Baglanti.Close();

            }
        }

        private void veriDüzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
