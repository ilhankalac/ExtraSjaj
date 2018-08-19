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
    public partial class DodavanjeTepihaControl : UserControl
    {
        //public DodavanjeTepihaControl()
        //{
        //    InitializeComponent();
        //}
        public DodavanjeTepihaControl()
        {
            InitializeComponent();
           
        }
        Modeli.Musterija musterija1 = new Modeli.Musterija();
        Tepih tepih = new Tepih();
        public void ucitavanjeTepihaSelektovanogMusterije(Musterija musterija)
        {
            musterija1 = musterija;
            tepih.ucitavanjeTepihaSelektovanogMusterije(musterija, label1, label5, label6, dataGridView1);
        }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        
        void updateMusterijuNakonDodavanjaIBrisanjaTepiha()
        {
            konekcija.Open();
            SqlCommand cmdUpdateMusterije = new SqlCommand(@"update Musterijas
                                                set BrojTepiha = " + "(select count(MusterijaId) " +
                                               " from Tepisi where MusterijaId = " + musterija1.Id.ToString() + " )" 
                                               + " where Id = " + musterija1.Id.ToString(), konekcija);

            SqlCommand cmdUpdateRacuna = new SqlCommand(@"update Racuni
                                                set Racun = " + racun().ToString() +
                                               "  where MusterijaId = " + musterija1.Id.ToString()  , konekcija);
            cmdUpdateMusterije.ExecuteNonQuery();
            cmdUpdateRacuna.ExecuteNonQuery();
            konekcija.Close();
            //frmPocetna frm1 = new frmPocetna();
            ////citaj tabelu za tepihe tu treba
            //musterija1.citajTabeluMusterijeFromSql(dataGridView1);

        }

        

        public void IscitajTabeluTepisiZaMusteriju()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select t.id, m.ImePrezime , t.Sirina as 'Širina/m' ," +
                                                    " t.Duzina as 'Dužina/m'  , t.Kvadratura as 'Kvadratura/m2'  " +
                                                    "from Tepisi t join Musterijas m on m.Id = t.MusterijaId" +
                                                    " where m.Id = " + musterija1.Id, konekcija);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnZaBrisanjeTepiha_Click(object sender, EventArgs e)
        {



        }
        void racunZaMusteriju()
        {

            label2.Text = "Račun:";
            label2.Text += " " + racun().ToString() + " EUR";
            textBox3.Text = racun().ToString();

        }


        double racun()
        {

            double racun = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                //var nesto = item.Cells[3].Value.ToString();
                racun += Convert.ToDouble(item.Cells[4].Value.ToString());

            }
            return Math.Round(racun * Convert.ToDouble(comboBox1.Text), 2);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


        private void TepisiMusterije_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateMusterijuNakonDodavanjaIBrisanjaTepiha();
        }

       
        void updateMusterijuNakonPlacanja()
        {
            int platio = 0;
            if (racun() == Convert.ToDouble(textBox3.Text))
                platio = 1;
            else
                platio = 0;


            konekcija.Open();

            SqlCommand komanda = new SqlCommand(@"update Musterijas set Platio = " + platio + "  where Id = " + musterija1.Id.ToString(), konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }

      
        private void btnDodajTepih_Click_1(object sender, EventArgs e)
        {
            tepih.DodajTepih(textBox1.Text, textBox2.Text, musterija1.Id);
            IscitajTabeluTepisiZaMusteriju();
            racunZaMusteriju();
            updateMusterijuNakonDodavanjaIBrisanjaTepiha();
        }

        private void btnNaplati_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li si siguran da je mušterija platio?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ((dialogResult == DialogResult.Yes) && Convert.ToDouble(textBox3.Text) <= racun() && Convert.ToDouble(textBox3.Text) > 0)
            {
                updateMusterijuNakonPlacanja();
                MessageBox.Show("Uspešno naplaćeno.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }

            else if (Convert.ToDouble(textBox3.Text) > racun() || Convert.ToDouble(textBox3.Text) < 0)
            {
                MessageBox.Show("Ispravno unesi koliko је mušterija ostavio novca.(ne mozeš uneti negativan broj, niti više od njegovog računa.");
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            racunZaMusteriju();
        }
        
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (MessageBox.Show("Da li si siguran da zelis obrisati selektovani tepih?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string idSelektovanogTepiha = dataGridView1.SelectedCells[0].Value.ToString();
                SqlCommand komanda = new SqlCommand(@"delete from Tepisi
                                                    where id = " + idSelektovanogTepiha, konekcija);

                konekcija.Open();
                komanda.ExecuteNonQuery();
                konekcija.Close();
                IscitajTabeluTepisiZaMusteriju();
                racunZaMusteriju();
                updateMusterijuNakonDodavanjaIBrisanjaTepiha();

            }
        }
    }
}
