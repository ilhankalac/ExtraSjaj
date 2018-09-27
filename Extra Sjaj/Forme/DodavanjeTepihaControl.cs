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
   
        Racun Racun = new Racun();
        public DodavanjeTepihaControl()
        {
            InitializeComponent();
        }
    
        Modeli.Musterija Musterija = new Modeli.Musterija();
        public Tepih tepih = new Tepih();
        public void ucitavanjeTepihaSelektovanogMusterije(Musterija musterija, int IdRacuna)
        {
            Musterija = musterija;
           // tepih.ucitavanjeTepihaSelektovanogMusterije(musterija, label1, label5, label6, dataGridView1, IdRacuna, btnNaplati, btnDodajTepih,textBox1, textBox2);
        }
        public void ucitavanjeTepihaSelektovanogMusterije(Musterija musterija)
        {
            konekcija.Open();
            SqlCommand kmnGetIdRacuna = new SqlCommand("select max(Id) from Racuni where MusterijaId = " + musterija.Id, konekcija);
            Musterija = musterija;
           // tepih.ucitavanjeTepihaSelektovanogMusterije(musterija, label1, label5, label6, dataGridView1, Convert.ToInt32(kmnGetIdRacuna.ExecuteScalar()), btnNaplati, btnDodajTepih,textBox1, textBox2);
        }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        
        void updateMusterijuNakonDodavanjaIBrisanjaTepiha()
        {
            konekcija.Open();
            //ostaje ti da implementiras novu funkciju  
         
            konekcija.Close();
        }

       

        public void IscitajTabeluTepisiZaMusteriju(int IdRacuna)
        {
            try
            {
                konekcija.Open();
                tepih.popunjavanjeListeTepiha(listBox1, IdRacuna);

                SqlDataAdapter sda = new SqlDataAdapter("select t.id , t.Sirina as 'Širina/m' ," +
                                                        " t.Duzina as 'Dužina/m'  , t.Kvadratura as 'Kvadratura/m2'  " +
                                                        "from Tepisi t join Racuni r on r.Id = t.RacunId" +
                                                        " where r.Id = " + IdRacuna, konekcija);
                DataTable dt = new DataTable();


                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                racunZaMusteriju();
               
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
        public void IscitajTabeluTepisiZaMusteriju()
        {
            konekcija.Open();


            SqlDataAdapter sda = new SqlDataAdapter("select t.id , t.Sirina as 'Širina/m' ," +
                                                    " t.Duzina as 'Dužina/m'  , t.Kvadratura as 'Kvadratura/m2'  " +
                                                    "from Tepisi t join Racuni r on r.Id = t.RacunId" +
                                                    " where r.Id = " + DodavanjeMusterijeControl.IdRacuna.ToString(), konekcija);
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

            SqlCommand cmdUpdateRacuna = new SqlCommand(@"update Racuni
                                                set Racun = " + racun().ToString() +
                                                        "  where id = "+DodavanjeMusterijeControl.IdRacuna, konekcija);
            cmdUpdateRacuna.ExecuteNonQuery();


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

            SqlCommand komanda = new SqlCommand(@"update Racuni set Placen = " + platio + "  where id = " + DodavanjeMusterijeControl.IdRacuna, konekcija);
            komanda.ExecuteNonQuery();
            konekcija.Close();
        }

      
        private void btnDodajTepih_Click_1(object sender, EventArgs e)
        {

            tepih.DodajTepih(textBox1.Text, textBox2.Text, Musterija.Id, DodavanjeMusterijeControl.IdRacuna);
            IscitajTabeluTepisiZaMusteriju();
            racunZaMusteriju();
            updateMusterijuNakonDodavanjaIBrisanjaTepiha();
            updateRacunNakonDodavanjaTepiha();
            tepih.popunjavanjeListeTepiha(listBox1, DodavanjeMusterijeControl.IdRacuna);
           
        }
        void racunNaplacen()
        {
            if (label6.Text == "Plaćeno:  Da")
            {
                btnDodajTepih.Visible = false;
                btnNaplati.Visible = false;
            }
        }
        private void btnNaplati_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li si siguran da je mušterija platio?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ((dialogResult == DialogResult.Yes) && Convert.ToDouble(textBox3.Text) <= racun() && Convert.ToDouble(textBox3.Text) > 0)
            {
                updateRacunNakonPlacanja();
                MessageBox.Show("Uspešno naplaćeno.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
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
            racunNaplacen();
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

        private void button1_Click(object sender, EventArgs e)
        {

            this.Visible = false;
        }
    }
}
