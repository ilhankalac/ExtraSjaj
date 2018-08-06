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

      

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet1.Musterijas' table. You can move, or remove it, as needed.
            this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);
            // TODO: This line of code loads data into the '_TepisiBaza_2018DataSet.Musterijas' table. You can move, or remove it, as needed.
            this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);

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
                listBox1.Items.Add(item["Id"].ToString() + ". " + item["Ime i Prezime"].ToString() + item["Broj Tepiha"].ToString() + " = " + item["Broj Telefona"].ToString() +" "+ item["Adresa"].ToString());
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
            DataTable mojaTabela = citajTabeluMusterije();

            DataRow novaVrsta = mojaTabela.NewRow();
            novaVrsta["Ime i Prezime"] = textBox1.Text;
            novaVrsta["Broj Telefona"] = textBox2.Text;
            novaVrsta["Broj Tepiha"] = 4;
            novaVrsta["Adresa"] = textBox3.Text;

            mojaTabela.Rows.Add(novaVrsta);
            da.Update(mojaTabela);
            this.musterijasTableAdapter1.Fill(this._TepisiBaza_2018DataSet1.Musterijas);

        }

        private void btnBrisiMusteriju_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                dataGridView1.Rows.RemoveAt(row.Index);
            this.musterijasTableAdapter1.Update(_TepisiBaza_2018DataSet1);
        }

        private void btnUpdateMusterija_Click(object sender, EventArgs e)
        {
            this.musterijasTableAdapter1.Update(_TepisiBaza_2018DataSet1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
