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
            textBox4_KeyPress(new object(), new  KeyPressEventArgs(' '));
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
        List<int> listaId = new List<int>();
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            listView1.Items.Clear();

            //sql za pretrazivanje po imenu musterije
            SqlDataAdapter komandaPretrazivanja = new SqlDataAdapter("select id, imeprezime, platio, VremeDolaskaTepiha from Musterijas" +
                " where ImePrezime like '%"+textBox4.Text+"%'", konekcija);

            DataTable dt = new DataTable();
            komandaPretrazivanja.Fill(dt);

            dataGridView1.DataSource = dt;
            
            int i = 1;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                listView1.Items.Add((i++.ToString()) +". "+item.Cells[1].Value.ToString());
               listaId.Add(Convert.ToInt32(item.Cells[0].Value));
            }

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //promenljiva sa kojom dobijam id selektovanog musterije
            // MessageBox.Show(listaId[listView1.SelectedIndices[0]].ToString());

            //dodavanjeTepihaControl1.ucitavanjeTepihaSelektovanogMusterije(idSelektovaneMusterije, ImeSelektovanogMusterije, VremeDolaskaTepiha, placeno);
            //dodavanjeTepihaControl1.Visible = true;
            try
            {
                konekcija.Open();
                SqlCommand kmnGetIme = new SqlCommand("select ImePrezime from Musterijas where id = " + listaId[listView1.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetBrojTelefona = new SqlCommand("select BrojTelefona from Musterijas where id = " + listaId[listView1.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetAdresa = new SqlCommand("select Adresa from Musterijas where id = " + listaId[listView1.SelectedIndices[0]].ToString(), konekcija);

                textBox1.Text = kmnGetIme.ExecuteScalar().ToString();
                textBox2.Text = kmnGetBrojTelefona.ExecuteScalar().ToString();
                textBox3.Text = kmnGetAdresa.ExecuteScalar().ToString();

                konekcija.Close();
            }
            catch 
            {
                MessageBox.Show("Pogrešno ste izabrali mušteriju.");
            }

        }
    }
}
