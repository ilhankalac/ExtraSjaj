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
        Racun racun1 = new Racun();
        public DodavanjeTepihaControl()
        {
            InitializeComponent();
            


        }
    
        Modeli.Musterija musterija1 = new Modeli.Musterija();
        public Tepih tepih = new Tepih();
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
                                                set BrojTepiha = " + "(select count(RacunId) " +
                                               " from Tepisi where RacunId = " + racun1.Id.ToString() + " )" 
                                               + " where Id = " + musterija1.Id.ToString(), konekcija);

            SqlCommand cmdUpdateRacuna = new SqlCommand(@"update Racuni
                                                set Racun = " + racun().ToString() +
                                               "  where MusterijaId = " + racun1.Id.ToString()  +
                                               " and id = "+ 1048, konekcija);
            cmdUpdateMusterije.ExecuteNonQuery();
            cmdUpdateRacuna.ExecuteNonQuery();
            konekcija.Close();
            //frmPocetna frm1 = new frmPocetna();
            ////citaj tabelu za tepihe tu treba
            //musterija1.citajTabeluMusterijeFromSql(dataGridView1);

        }

        public void PuniComboDolaska()
        {

            SqlDataAdapter sda = new SqlDataAdapter("select m.id, m.VremeKreiranjaMusterije from Musterijas m " +
                                                    " where m.Id = " + musterija1.Id, konekcija);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "VremeDolaskaTepiha";
            comboBox2.ValueMember = "Id";
        }

        public void IscitajTabeluTepisiZaMusteriju()
        {
            konekcija.Open();
            SqlCommand kmnGetIdRacuna = new SqlCommand("select max(Id) from Racuni where MusterijaId = " + musterija1.Id, konekcija);


            SqlDataAdapter sda = new SqlDataAdapter("select t.id , t.Sirina as 'Širina/m' ," +
                                                    " t.Duzina as 'Dužina/m'  , t.Kvadratura as 'Kvadratura/m2'  " +
                                                    "from Tepisi t join Racuni r on r.Id = t.RacunId" +
                                                    " where r.Id = "+kmnGetIdRacuna.ExecuteScalar().ToString(), konekcija);
            DataTable dt = new DataTable();

            
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            racunZaMusteriju();
            konekcija.Close();
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
                racun += Convert.ToDouble(item.Cells[3].Value.ToString());

            }
            return Math.Round(racun * Convert.ToDouble(comboBox1.Text), 2);
        }


        private void TepisiMusterije_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateMusterijuNakonDodavanjaIBrisanjaTepiha();
        }

        void updateRacunNakonDodavanjaTepiha()
        {
            

            konekcija.Open();

            SqlCommand komanda = new SqlCommand(@"update Racuni set Racun = " +textBox3.Text + "  where MusterijaId = " + musterija1.Id.ToString(), konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }
        void updateRacunNakonPlacanja()
        {
            int platio = 0;
            if (racun() == Convert.ToDouble(textBox3.Text))
                platio = 1;
            else
                platio = 0;


            konekcija.Open();

            SqlCommand komanda = new SqlCommand(@"update Racuni set Placen = " + platio + "  where MusterijaId = " + musterija1.Id.ToString(), konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }

      
        private void btnDodajTepih_Click_1(object sender, EventArgs e)
        {
            PuniComboDolaska();
            tepih.DodajTepih(textBox1.Text, textBox2.Text, musterija1.Id);
            IscitajTabeluTepisiZaMusteriju();
            racunZaMusteriju();
            updateMusterijuNakonDodavanjaIBrisanjaTepiha();
            updateRacunNakonDodavanjaTepiha();
        }

        private void btnNaplati_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li si siguran da je mušterija platio?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ((dialogResult == DialogResult.Yes) && Convert.ToDouble(textBox3.Text) <= racun() && Convert.ToDouble(textBox3.Text) > 0)
            {
                updateRacunNakonPlacanja();
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
            updateRacunNakonDodavanjaTepiha();
        }
        
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (MessageBox.Show("Da li si siguran da zelis obrisati selektovani tepih?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tepih.BrisanjeTepiha(dataGridView1.SelectedCells[0].Value.ToString());
                IscitajTabeluTepisiZaMusteriju();
                racunZaMusteriju();
                updateMusterijuNakonDodavanjaIBrisanjaTepiha();

            }
        }
    }
}
