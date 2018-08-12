using ExtraSjaj.Modeli;
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

namespace ExtraSjaj
{
    public partial class frmMusterija : Form
    {
        public frmMusterija()
        {
            InitializeComponent();
        }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private void Tepisi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Tepisi' table. You can move, or remove it, as needed.
      

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            SqlCommand komanda = new SqlCommand(@"insert into Musterijas(ImePrezime,BrojTepiha,BrojTelefona, Adresa,Platio, VremeDOlaskaTepiha)" +
              "values (('" + textBox1.Text.ToString() + "')," +
              "('" +0.ToString() + "')," +
               "('" + textBox2.Text.ToString() + "')," +
              "('" + textBox3.Text.ToString() + "')," +
              "('" + false.ToString() + "')," +
              "('" + DateTime.Now.ToString() + "')); ", konekcija);

            konekcija.Open();
            komanda.ExecuteNonQuery();
            konekcija.Close();
            MessageBox.Show("Mušterija uspešno dodat u bazi.","Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
