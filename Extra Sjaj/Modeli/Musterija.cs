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
            SqlCommand kmdZaInsertMusterije = new SqlCommand(@"insert into Musterijas(ImePrezime,BrojTepiha,BrojTelefona, Adresa, VremeKreiranjaMusterije)" +
             "values (('" + ImePrezime.ToString() + "')," +
             "('" + 0.ToString() + "')," +
              "('" + BrojTelefona.ToString() + "')," +
             "('" + Adresa.ToString() + "')," +
             "(getdate())); ", konekcija);


            SqlCommand kmdZaInsertRacunaMusterije = new SqlCommand("insert into Racuni (Racun, MusterijaId, KreiranjeRacuna,Placen)" +
                "values (0, (SELECT SCOPE_IDENTITY()), getdate(),0)", konekcija);

            konekcija.Open();
            kmdZaInsertMusterije.ExecuteNonQuery();
            kmdZaInsertRacunaMusterije.ExecuteNonQuery();
            konekcija.Close();
           
        }
        public void citajTabeluMusterijeFromSql(DataGridView dataGridView1)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select m.id,row_number() over (order by m.Id) as 'Br.Mušterije'," +
                "m.ImePrezime as 'Ime i Prezime',m.BrojTepiha as 'Br.Tepiha',m.BrojTelefona as 'Br. Tel.',m.Adresa, " +
                "sum(isnull(t.kvadratura,0)) as 'Kvadratura Tepiha', m.VremeKreiranjaMusterije as 'Musterija Kreiran',r.Racun as 'Račun', r.Placen as 'Plaćeno' " +
                "from Musterijas m left join Tepisi t on t.RacunId = m.Id join Racuni r on r.MusterijaId = m.Id " +
                " where  datediff(month , r.KreiranjeRacuna, getdate()) = 0 " +
                "group by m.id, m.ImePrezime, m.BrojTepiha, m.BrojTelefona, m.Adresa, m.VremeKreiranjaMusterije,r.Racun, r.Placen" +
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
        public void IzmeniMusteriju(int idMusterije, string imePrezime, string adresa, string brojTelefona)
        {
            konekcija.Open();
            SqlCommand komanda = new SqlCommand(@"update Musterijas 
                set ImePrezime = '" + imePrezime + "', BrojTelefona = '" + brojTelefona  + "', Adresa = '" + adresa + "' where Id = " +idMusterije, konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }
        public void BrisiMusteriju(int Id)
        {
            konekcija.Open();
            SqlCommand komanda = new SqlCommand(@"delete Musterijas where Id = " + Id, konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();

        }

    }
}
