using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.Modeli
{
    public class Racun
    {
        public int Id { get; set; }
        public double RacunKolumn { get; set; }
        public int MusterijaId { get; set; }
        public DateTime DatumKreiranjaRacuna { get; set; }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);


        public int BrojRacuna(int idMusterije)
        {
            konekcija.Open();
            SqlCommand kmnGetCount = new SqlCommand("select count(Id) from Racuni where MusterijaId = " + idMusterije.ToString(), konekcija);
            int pom = Convert.ToInt32(kmnGetCount.ExecuteScalar());
            konekcija.Close();
            return pom;
        }

        public void kreirajNoviRacun(int idMusterije)
        {
            konekcija.Open();
            SqlCommand kmdZaInsertRacuna = new SqlCommand("insert into Racuni (Racun, MusterijaId, KreiranjeRacuna, Placen) " +
                "values (0, "+idMusterije+", getdate(), false)", konekcija);
            kmdZaInsertRacuna.ExecuteNonQuery();
            konekcija.Close();

        }

    }
}
