using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Musterijas' table. You can move, or remove it, as needed.
            //this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);
            //// TODO: This line of code loads data into the '_TepisiBaza_2018DataSet.Musterijas' table. You can move, or remove it, as needed.
            //this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);
            citajTabeluMusterijeFromSql();
        }
        void citajTabeluMusterijeFromSql()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select m.id,row_number() over (order by m.Id) as 'Br.Mušterije',m.ImePrezime as 'Ime i Prezime',m.BrojTepiha as 'Br.Tepiha',m.BrojTelefona as 'Br. Tel.',m.Adresa, sum(isnull(t.kvadratura,0)) as 'Kvadratura Tepiha' from Musterijas m left join Tepisi t on t.MusterijaId = m.Id group by m.id, m.ImePrezime, m.BrojTepiha, m.BrojTelefona, m.Adresa order by m.Id asc", konekcija);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            puniKomboBrojeva();
            puniListuMusterija();
        }
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
        private DataTable citajTabeluBrojeva()
        {
            SqlConnection konekcija = new SqlConnection(Konekcija.konString);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select *from Broj", konekcija);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Fill(ds, "Broj");

            DataTable mojaTabela = ds.Tables["Broj"];
            return mojaTabela;
        }

       
        private void puniListuMusterija()
        {
            DataTable mojaTabela = citajTabeluMusterije();


            foreach (DataRow item in mojaTabela.Rows)
            {
                listBox1.Items.Add(item["Id"].ToString() + ". " + item["ImePrezime"].ToString() + item["BrojTepiha"].ToString() + " = " + item["BrojTelefona"].ToString() +" "+ item["Adresa"].ToString());
            }



        }
        private void puniKomboBrojeva()
        {
            DataTable mojaTabela = citajTabeluBrojeva();
            comboBox1.DataSource = mojaTabela;

            comboBox1.DisplayMember = "Broj";
            comboBox1.ValueMember = "Id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private SqlDataAdapter da = null;

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            SqlCommand komanda = new SqlCommand(@"insert into Musterijas(ImePrezime,BrojTepiha,BrojTelefona, Adresa)" +
                "values (('" + textBox1.Text.ToString() + "')," +
                "(" + comboBox1.SelectedValue.ToString() + ")," +
                "('" + textBox2.Text.ToString() + "')," +
                "('" + textBox3.Text.ToString() + "')); ", konekcija);

            konekcija.Open();
            komanda.ExecuteNonQuery();
            konekcija.Close();
            citajTabeluMusterijeFromSql();

        }

        private void btnBrisiMusteriju_Click(object sender, EventArgs e)
        {
            int[] nizId = new int[100];
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Cells[0].Value == null) break;
                dataGridView1.Rows.RemoveAt(row.Index);
                nizId[i++] = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            }
            string spajanjeId = "";
            for (int k = 0; k < i; k++)
            {
                spajanjeId += nizId[k]+", ";
            }
           
            //SqlCommand komanda = new SqlCommand(@"delete from Musterijas where id in ("
            //+
            //    , konekcija);

            konekcija.Open();
           // komanda.ExecuteNonQuery();
            konekcija.Close();

            this.musterijasTableAdapter1.Update(_TepisiBaza_2018DataSet1);
        }

        private void btnUpdateMusterija_Click(object sender, EventArgs e)
        {
            this.musterijasTableAdapter1.Update(_TepisiBaza_2018DataSet1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tepisi tepisi = new Tepisi();
            tepisi.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            string idSelektovaneMusterije = dataGridView1.SelectedCells[0].Value.ToString();
            string ImeSelektovanogMusterije = dataGridView1.SelectedCells[2].Value.ToString();
            TepisiMusterije tepisiMusterije = new TepisiMusterije(idSelektovaneMusterije, ImeSelektovanogMusterije);
            tepisiMusterije.ShowDialog();
        }
    }
    }
