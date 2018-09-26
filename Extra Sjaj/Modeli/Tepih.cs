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
        public void ucitavanjeTepihaSelektovanogMusterije(Musterija musterija, Label label1, Label label5, Label label6, DataGridView dataGridView1, int IdRacuna, Button btnNaplati, Button btnDodajTepih)
        {
            konekcija.Open();


            label5.Text = "";
            label6.Text = "Plaćeno: ";

            //            this.musterija1 = musterija;

            SqlDataAdapter sda = new SqlDataAdapter("select  t.id,row_number() over (order by t.RacunId) as 'Br. Tepiha', t.Sirina as 'Širina/m', " +
                                                    "t.Duzina as 'Dužina/m',  t.Kvadratura as 'Kvadratura/m2'  " +
                                                    "from Tepisi t join Racuni r on r.Id = t.RacunId where t.RacunId = " + IdRacuna.ToString(), konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            SqlCommand getStatusRacuna = new SqlCommand("select Placen from Racuni where id = " + IdRacuna, konekcija);
            int statusRacuna = Convert.ToInt32(getStatusRacuna.ExecuteScalar());
            dataGridView1.DataSource = dt;
            label1.Text = musterija.ImePrezime + " - tepisi";
            label5.Text = "Tepisi dostavljeni na pranje: " + musterija.VremeDolaskaTepiha.Day.ToString() + "/" + musterija.VremeDolaskaTepiha.Month.ToString() + "/" + musterija.VremeDolaskaTepiha.Year.ToString();
            if (statusRacuna == 1)
            {
                label6.Text += " Da";
                btnDodajTepih.Visible = false;
                btnNaplati.Visible = false;
            }
            else {
                label6.Text += " Ne";
                btnDodajTepih.Visible = true;
                btnNaplati.Visible = true;

            } 
            konekcija.Close();
            //musterija.Racun = racun();
            //racunZaMusteriju();
        }


       
        public void DodajTepih(string duzina, string sirina, int MusterijaId, int IdRacuna)
        {
            konekcija.Open();
           

            SqlCommand komanda = new SqlCommand(@"insert into Tepisi(Duzina,Sirina,Kvadratura, RacunId)" +
              "values ((" + duzina.ToString() + ")," +
              "(" + sirina.ToString() + ")," +
              "(" + Convert.ToDouble(duzina) * Convert.ToDouble(sirina) + ")," +
              "("+ IdRacuna.ToString() +")); ", konekcija);

         
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }
        public void BrisanjeTepiha(string idSelektovanogTepiha)
        {
            SqlCommand komanda = new SqlCommand(@"delete from Tepisi
                                                    where id = " + idSelektovanogTepiha, konekcija);

            konekcija.Open();
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }



    }
}
