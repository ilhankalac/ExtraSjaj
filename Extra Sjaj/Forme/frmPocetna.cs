using ExtraSjaj.Forme;
using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj
{
    public partial class frmPocetna : Form
    {
        public frmPocetna()
        {
            InitializeComponent();
        }

        public Musterija musterija;
        public Racun Racun;
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private SqlDataAdapter da = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            musterija = new Musterija();
            musterija.citajTabeluMusterijeFromSql(dataGridView1);
            label1.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);
            label1.Text +="/"+ DateTime.Now.Year.ToString();
            dodavanjeMusterijeControl1.Visible = false;
            arhivaMusterijaControl1.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = false;

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

      
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            arhivaMusterijaControl1.Visible = false;
            musterija.citajTabeluMusterijeFromSql(dataGridView1);
            dodavanjeTepihaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = true;
            listaRacuna.Visible = false;
        }

    

        private void btnUpdateMusterija_Click(object sender, EventArgs e)
        {

           //i ovu
        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            //frmMusterija tepisi = new frmMusterija();
          //  tepisi.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                
                int rowIndex = dataGridView1.CurrentRow.Index;
                musterija.Id = Convert.ToInt32( dataGridView1.SelectedCells[0].Value);
                musterija.ImePrezime = dataGridView1.SelectedCells[2].Value.ToString();
                musterija.VremeDolaskaTepiha = Convert.ToDateTime( dataGridView1.SelectedCells[7].Value);
     

               
                dodavanjeTepihaControl1.Refresh();
                dodavanjeTepihaControl1.Visible = true;
                dodavanjeMusterijeControl1.Refresh();
           

                dodavanjeTepihaControl1.IscitajTabeluTepisiZaMusteriju();


            }
            catch 
            {
                MessageBox.Show("Pogrešno ste izabrali mušteriju.");
            }
           
        }

        private void pogledajArhivuMušterijaKojiSuPlatiliToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // frmArhivaMusterija frm = new frmArhivaMusterija();
           // frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //frmArhivaMusterija frm = new frmArhivaMusterija();
            //frm.ShowDialog();
            arhivaMusterijaControl1.Visible = true ;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            musterija.citajTabeluMusterijeFromSql(dataGridView1);
            dodavanjeMusterijeControl1.Visible = false;
            arhivaMusterijaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //da se otvori lista musterija kada napravis user controler novi
        }

        private void frmPocetna_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listaRacuna.Items.Clear();
            listaRacuna.Visible = true;
            Racun = new Racun();
            int i = 0;
            foreach (var item in Racun.recnikRacuna())
            {
                
                listaRacuna.Items.Add(item.Value);
                if (item.Value.Contains("True"))
                    listaRacuna.Items[i].BackColor = Color.Green;
                else
                    listaRacuna.Items[i].BackColor = Color.Red;
                i++;
            }
        }
    }
    }
