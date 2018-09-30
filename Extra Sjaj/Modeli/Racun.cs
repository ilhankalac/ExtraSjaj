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

        public void updateRacunaNakonDodavanjaTepiha(int idRacuna, int brojTepiha)
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

    }
}
