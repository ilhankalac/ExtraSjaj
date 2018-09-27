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

     

       public Dictionary<int, string> popunjavanjeListeTepiha(int IdRacuna)
        {
            Dictionary<int, string> listaTepiha = new Dictionary<int, string>();
            try
            {
               
                konekcija.Open();
                SqlCommand kmdSelektTepiha = new SqlCommand("select * from tepisi where racunId = " + IdRacuna, konekcija);
                SqlDataReader reader = kmdSelektTepiha.ExecuteReader();
                listaTepiha.Clear();
                int i = 1;
                while (reader.Read())
                    listaTepiha.Add(Convert.ToInt32(reader["Id"]), ((i++).ToString() + ". " + reader["Duzina"] + " X " + reader["Sirina"] + " = " + reader["Kvadratura"] + " m²").ToString());

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }

            return listaTepiha;
        }


        public void DodajTepih(string duzina, string sirina, int MusterijaId, int IdRacuna)
        {
            try
            {

                konekcija.Open();
                SqlCommand kmdZaInsertTepiha = new SqlCommand(@"
                                               insert into Tepisi(Duzina,Sirina,Kvadratura, RacunId)" +
                                              "values ((" + duzina.ToString() + ")," +
                                              "(" + sirina.ToString() + ")," +
                                              "(" + Convert.ToDouble(duzina) * Convert.ToDouble(sirina) + ")," +
                                              "(" + IdRacuna.ToString() + ")); ", konekcija);

                kmdZaInsertTepiha.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
           
            konekcija.Close();
        }


        public void BrisanjeTepiha(string idSelektovanogTepiha)
        {
            
            try
            {
                konekcija.Open();
                SqlCommand kmdZaBrisanje = new SqlCommand(@"delete from Tepisi
                                                 where id = " + idSelektovanogTepiha, konekcija);
                kmdZaBrisanje.ExecuteNonQuery();
              
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



    }
}
