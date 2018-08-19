using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.Modeli
{
    public class Tepih
    {
        public int Id { get; set; }
        public float Duzina { get; set; }
        public float Sirina { get; set; }
        public int MusterijaId { get; set; }
        public float Kvadratura { get; set; }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        public void ucitavanjeTepihaSelektovanogMusterije(Musterija musterija, Label label1, Label label5, Label label6, DataGridView dataGridView1)
        {
            label5.Text = "";
//            this.musterija1 = musterija;

            SqlDataAdapter sda = new SqlDataAdapter("select  t.id,row_number() over (order by t.MusterijaId) as 'Br. Tepiha', t.Sirina as 'Širina/m', " +
                                                    "t.Duzina as 'Dužina/m',  t.Kvadratura as 'Kvadratura/m2'  " +
                                                    "from Tepisi t join Musterijas m on m.Id = t.MusterijaId where t.MusterijaId = " + musterija.Id, konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);


            dataGridView1.DataSource = dt;
            label1.Text = musterija.ImePrezime + " - tepisi";
            label5.Text = "Tepisi dostavljeni na pranje: " + musterija.VremeDolaskaTepiha.Day.ToString() + "/" + musterija.VremeDolaskaTepiha.Month.ToString() + "/" + musterija.VremeDolaskaTepiha.Year.ToString();
            if (musterija.Platio) label6.Text += " Da"; else label6.Text += " Ne";

            //musterija.Racun = racun();
            //racunZaMusteriju();
        }
        public void DodajTepih(string duzina, string sirina, int MusterijaId)
        {
            SqlCommand komanda = new SqlCommand(@"insert into Tepisi(Duzina,Sirina,Kvadratura, MusterijaId)" +
              "values ((" + duzina.ToString() + ")," +
              "(" + sirina.ToString() + ")," +
              "(" + Convert.ToDouble(duzina) * Convert.ToDouble(sirina) + ")," +
              "(" + MusterijaId.ToString() + ")); ", konekcija);

            konekcija.Open();
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }



    }
}
