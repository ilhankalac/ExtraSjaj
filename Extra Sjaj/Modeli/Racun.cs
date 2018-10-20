using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.Modeli
{
    public class Racun
    {
        public int Id { get; set; }
        public double RacunKolumn { get; set; }
        public int MusterijaId { get; set; }
        public bool Placen { get; set; }
        public DateTime DatumKreiranjaRacuna { get; set; }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);


        public int BrojRacuna(int idMusterije)
        {
            int brojRacuna = 0;
            try
            {
                konekcija.Open();
                SqlCommand kmnGetCount = new SqlCommand("select count(Id) " +
                                        "from Racuni where MusterijaId = " + idMusterije.ToString(), konekcija);
                brojRacuna = Convert.ToInt32(kmnGetCount.ExecuteScalar());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
            return brojRacuna;
        }

        public void kreirajNoviRacun(int idMusterije)
        {
            try
            {
                konekcija.Open();
                SqlCommand kmdZaInsertRacuna = new SqlCommand("insert into Racuni " +
                                            "(Racun, MusterijaId, KreiranjeRacuna, Placen) " +
                                            "values (0, " + idMusterije + ", getdate(), 0)", konekcija);
                kmdZaInsertRacuna.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }

        }

        public void updateRacunaNakonPlacanja(int platio, int IdRacuna)
        {
            try
            {
                konekcija.Open();
                SqlCommand komanda = new SqlCommand(@"update Racuni set Placen = " + platio +
                                   "  where id = " + IdRacuna, konekcija);
                komanda.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }

        public void updateBrojaTepihaNakonDodavanjaTepiha(int idRacuna, int brojTepiha)
        {
            try
            {
                konekcija.Open();
                SqlCommand kmdUpdateBrojTepiha = new SqlCommand("update racuni set brojTepiha = " + brojTepiha + "" +
                    " where id = " + idRacuna, konekcija);

                kmdUpdateBrojTepiha.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }
        public void updateRacunNakonDodavanjaTepiha(double racun, int idRacuna)
        {
            try
            {
                konekcija.Open();

                SqlCommand cmdUpdateRacuna = new SqlCommand(@"update Racuni
                                             set Racun = " + racun.ToString() +
                                             " where id = " + idRacuna , konekcija);
                cmdUpdateRacuna.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }
        public Dictionary<int, string> recnikRacuna(bool ovajMjesec, int brojRacunaZaUzimanjeIzBaze)
        {
            Dictionary<int, string> recnikRacuna = new Dictionary<int, string>();
            try
            {
                string subQuery = "";
                konekcija.Open();
                if (ovajMjesec)
                    subQuery = " where Month(r.kreiranjeRacuna) = " + DateTime.Now.Month;
                    

                SqlCommand kmdSelektMusterija = new SqlCommand("select top "+brojRacunaZaUzimanjeIzBaze+ " r.musterijaid, r.id, m.ImePrezime, r.Placen, r.racun, r.KreiranjeRacuna " +
                    " from Racuni r join musterijas m on m.id = r.musterijaId" + subQuery+
                    " order by r.id desc, m.id" , konekcija);
                SqlDataReader reader = kmdSelektMusterija.ExecuteReader();
                recnikRacuna.Clear();
                int i = 1;
                while (reader.Read())
                    recnikRacuna.Add(Convert.ToInt32(reader["Id"]), (i++).ToString() + ". " 
                        + reader["ImePrezime"].ToString()+" Iznos: "+reader["racun"]
                        +" EUR. Platio: "+reader["placen"] +" Kreiran račun: "+reader["kreiranjeRacuna"]
                        +" ="+ reader["MusterijaId"]);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }

            return recnikRacuna;
        }
    }
}
