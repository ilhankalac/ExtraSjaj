using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExtraSjaj.Modeli;

namespace ExtraSjaj.Forme
{
    public partial class DodavanjeMusterijeControl : UserControl
    {
        public DodavanjeMusterijeControl()
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
            
        }

        private void btnDodaj_Click_1(object sender, EventArgs e)
        {
            SqlCommand kmdZaInsertMusterije = new SqlCommand(@"insert into Musterijas(ImePrezime,BrojTepiha,BrojTelefona, Adresa,Platio, VremeDOlaskaTepiha)" +
              "values (('" + textBox1.Text.ToString() + "')," +
              "('" + 0.ToString() + "')," +
               "('" + textBox2.Text.ToString() + "')," +
              "('" + textBox3.Text.ToString() + "')," +
              "('" + false.ToString() + "')," +
              "(getdate())); ", konekcija);
    

            SqlCommand kmdZaInsertRacunaMusterije = new SqlCommand("insert into Racuni (Racun, MusterijaId)" +
                "values (0, (SELECT SCOPE_IDENTITY()))", konekcija);

            konekcija.Open();
            kmdZaInsertMusterije.ExecuteNonQuery();
            kmdZaInsertRacunaMusterije.ExecuteNonQuery();
            konekcija.Close();
            MessageBox.Show("Mušterija uspešno dodat u bazi.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}
