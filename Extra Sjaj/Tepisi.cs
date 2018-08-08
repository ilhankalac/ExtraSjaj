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
    public partial class Tepisi : Form
    {
        public Tepisi()
        {
            InitializeComponent();
        }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private void Tepisi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Tepisi' table. You can move, or remove it, as needed.
            IscitajTabeluTepisi();

        }

        public void IscitajTabeluTepisi()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select m.ImePrezime , t.Sirina as 'Širina/m' , t.Duzina as 'Dužina/m'  , t.Kvadratura as 'Kvadratura/m2'  from Tepisi t join Musterijas m on m.Id = t.MusterijaId order by m.ImePrezime", konekcija);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komanda = new SqlCommand(@"insert into Tepisi(Duzina,Sirina,Kvadratura, MusterijaId)" +
                "values ((" + textBox1.Text.ToString() + ")," +
                "(" + textBox2.Text.ToString() + ")," +
                "(" + Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text) + ")," +
                "(" + textBox3.Text.ToString() + ")); ", konekcija);

            konekcija.Open();
            komanda.ExecuteNonQuery();
            konekcija.Close();
            IscitajTabeluTepisi();

        }
    }
}
