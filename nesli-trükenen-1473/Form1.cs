using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nesli_trükenen_1473
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ekle_1473 ekle = new Ekle_1473();
            ekle.Show();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele_1473 listele = new Listele_1473();
            listele.Show();
        }

    }
}
