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
            dataGridView1.Hide();
            puniListViewMusterijama();
        }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private void Tepisi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Tepisi' table. You can move, or remove it, as needed.


        }
        private SqlDataAdapter da = null;
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
        void puniListViewMusterijama()
        {
            listView1.Items.Clear();
            DataTable mojaTabela = citajTabeluMusterije();

            int i = 1;
            foreach (DataRow item in mojaTabela.Rows)
            {
                listView1.Items.Add((i++).ToString() + ". " + item["ImePrezime"].ToString());
            }

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
            puniListViewMusterijama();

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            listView1.Items.Clear();
            // MessageBox.Show("test");
            SqlDataAdapter komandaPretrazivanja = new SqlDataAdapter("select imeprezime from Musterijas" +
                " where ImePrezime like '%"+textBox4.Text+"%'", konekcija);

            DataTable dt = new DataTable();
            komandaPretrazivanja.Fill(dt);

            dataGridView1.DataSource = dt;
            int i = 1;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                listView1.Items.Add((i++.ToString()) +". "+item.Cells[0].Value.ToString());
            }

        }
    }
}
