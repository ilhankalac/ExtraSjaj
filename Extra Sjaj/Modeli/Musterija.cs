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
    public class Musterija
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public int BrojTepiha { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public DateTime VremeDolaskaTepiha { get; set; }
        public bool Platio { get; set; }

        public double Racun { get; set; }

        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        public void DodajMusteriju(string ImePrezime, string BrojTelefona, string Adresa)
        {
            SqlCommand kmdZaInsertMusterije = new SqlCommand(@"insert into Musterijas(ImePrezime,BrojTepiha,BrojTelefona, Adresa,Platio, VremeDOlaskaTepiha)" +
             "values (('" + ImePrezime.ToString() + "')," +
             "('" + 0.ToString() + "')," +
              "('" + BrojTelefona.ToString() + "')," +
             "('" + Adresa.ToString() + "')," +
             "('" + false.ToString() + "')," +
             "(getdate())); ", konekcija);


            SqlCommand kmdZaInsertRacunaMusterije = new SqlCommand("insert into Racuni (Racun, MusterijaId)" +
                "values (0, (SELECT SCOPE_IDENTITY()))", konekcija);

            konekcija.Open();
            kmdZaInsertMusterije.ExecuteNonQuery();
            kmdZaInsertRacunaMusterije.ExecuteNonQuery();
            konekcija.Close();
           
        }
        public void citajTabeluMusterijeFromSql(DataGridView dataGridView1)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select m.id,row_number() over (order by m.Id) as 'Br.Mušterije'," +
                "m.ImePrezime as 'Ime i Prezime',m.BrojTepiha as 'Br.Tepiha',m.BrojTelefona as 'Br. Tel.',m.Adresa, " +
                "sum(isnull(t.kvadratura,0)) as 'Kvadratura Tepiha', m.VremeDolaskaTepiha as 'Tepisi dostavljeni',r.Racun as 'Račun', m.Platio as 'Plaćeno' " +
                "from Musterijas m left join Tepisi t on t.MusterijaId = m.Id join Racuni r on r.MusterijaId = m.Id " +
                " where  datediff(month , m.VremeDolaskaTepiha, getdate()) = 0" +
                "group by m.id, m.ImePrezime, m.BrojTepiha, m.BrojTelefona, m.Adresa, m.VremeDolaskaTepiha,r.Racun, m.Platio" +
                " order by m.Id asc", konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            puniListuMusterija(new ListBox());
        }

        private void puniListuMusterija(ListBox listBox1)
        {
            DataTable mojaTabela = citajTabeluMusterije();
            foreach (DataRow item in mojaTabela.Rows)
            {
                listBox1.Items.Add(item["Id"].ToString() + ". " + item["ImePrezime"].ToString() + item["BrojTepiha"].ToString() + " = " + item["BrojTelefona"].ToString() + " " + item["Adresa"].ToString());
            }
        }
        SqlDataAdapter da = null;
        private DataTable citajTabeluMusterije()
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konString);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select *from Musterijas", konekcija);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Fill(ds, "Musterijas");

            DataTable mojaTabela = ds.Tables["Musterijas"];
            return mojaTabela;
        }
    }
}
