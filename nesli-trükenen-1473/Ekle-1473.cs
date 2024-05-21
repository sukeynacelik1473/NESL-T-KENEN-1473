using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace nesli_trükenen_1473
{
    public partial class Ekle_1473 : Form
    {
        string baglanti = "Server=localhost;Database=canli_veritabani;Uid=root;Pwd=;";
        string yeniAd = "";
        public Ekle_1473()
        {
            InitializeComponent();
        }

        private void Ekle_1473_Load(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (MySqlConnection baglan = new MySqlConnection(baglanti))
            {
                baglan.Open();
                string sorgu = "INSERT INTO canlilar VALUES(NULL,@ad,@yasadigi_ulke,@populasyon,@gorsel_ad);";

                MySqlCommand cmd = new MySqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@ad", txtAdi.Text);
                cmd.Parameters.AddWithValue("@yasadigi_ulke", txtUlke.Text);
                cmd.Parameters.AddWithValue("@populasyon", txtPopulasyon.Text);
                cmd.Parameters.AddWithValue("@gorsel_ad", pbResim.Text);



                //sorguyu çalıştırma komutu kayıt eklşenirse satır satıyısı döner
                if (cmd.ExecuteNonQuery() > 0)
                {
                    // MessageBox.Show("Kayıt Eklendi!");
                    // this.Close(); 
                }

            }
        }
        private void Ekle_Load(object sender, EventArgs e)
        {
            string klasorYolu = @"gorsel_ad";
            if (!Directory.Exists(klasorYolu))
            {
                Directory.CreateDirectory(klasorYolu);
            }

        }

        private void pbResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(this);

            if (result != DialogResult.OK) return;

            string kaynakDosya = openFileDialog.FileName;
            yeniAd = Guid.NewGuid().ToString() + Path.GetExtension(kaynakDosya);
            string hedefDosya = Path.Combine(Environment.CurrentDirectory, "gorsel_ad", yeniAd);

            File.Copy(kaynakDosya, hedefDosya);

            pbResim.ImageLocation = null;

            if (File.Exists(hedefDosya))
            {
                pbResim.ImageLocation = hedefDosya;
                pbResim.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
