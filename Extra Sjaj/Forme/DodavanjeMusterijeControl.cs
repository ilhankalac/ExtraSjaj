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
        Racun racun = new Racun();
        Musterija musterija;
        public DodavanjeMusterijeControl()
        {
            InitializeComponent();
            dataGridView1.Hide();
            musterija = new Musterija();
            puniListBoxMusterijama();
            dodavanjeTepihaControl1.Visible = false;
            textBox4_KeyPress(new object(), new  KeyPressEventArgs(' '));


            /* linija koja gasi metodu combobxo selected index changed, samo dodaj + da ispred
             = da bi je vratio nazad da funkcionise*/
            comboBox1.SelectedIndexChanged -= new System.EventHandler(comboBox1_SelectedIndexChanged);

        }
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private void Tepisi_Load(object sender, EventArgs e)
        {
           
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
        void puniListBoxMusterijama()
        {
            textBox4_KeyPress(new object(), new KeyPressEventArgs(' '));
            listBox1.Items.Clear();
            var djesi = musterija.listaMusterija();

            foreach (var musterija in musterija.listaMusterija())
                listBox1.Items.Add(musterija.Value);
            
        }
        
        private void btnDodaj_Click_1(object sender, EventArgs e)
        {
            musterija.DodajMusteriju(textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Mušterija uspešno dodat u bazi.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            puniListBoxMusterijama();
        }
        List<int> listaId = new List<int>();
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            listaId.Clear();
            listBox1.Items.Clear();

            var rezultatPretrage = musterija.listaPretrageMusterija(textBox4.Text);
            int i = 1;
            foreach (var musterija in rezultatPretrage)
            {
                listBox1.Items.Add((i++.ToString()) + ". " + musterija.Value.ToString());
                listaId.Add(Convert.ToInt32(musterija.Key));
            }
                
        }

        
       

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.comboBox1.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                puniComboRacuna();
                konekcija.Open();

                SqlCommand kmnGetIme = new SqlCommand("select ImePrezime from Musterijas where id = " + listaId[listBox1.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetBrojTelefona = new SqlCommand("select BrojTelefona from Musterijas where id = " + listaId[listBox1.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetAdresa = new SqlCommand("select Adresa from Musterijas where id = " + listaId[listBox1.SelectedIndices[0]].ToString(), konekcija);

                textBox1.Text = kmnGetIme.ExecuteScalar().ToString();
                textBox2.Text = kmnGetBrojTelefona.ExecuteScalar().ToString();
                textBox3.Text = kmnGetAdresa.ExecuteScalar().ToString();

                //prikaz broja racuna selektovanog musterije
                label6.Text = racun.BrojRacuna(Convert.ToInt32(listaId[listBox1.SelectedIndices[0]])).ToString();
               
                // this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                dodavanjeTepihaControl1.ucitavanjeTepihaSelektovanogMusterije(musterija, Convert.ToInt32(comboBox1.SelectedValue));
            }
            catch
            {
                MessageBox.Show("Pogrešno ste izabrali mušteriju.");
            }
            finally
            {
                konekcija.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            musterija.IzmeniMusteriju(Convert.ToInt32(listaId[listBox1.SelectedIndices[0]]), textBox1.Text, textBox3.Text, textBox2.Text);
            puniListBoxMusterijama();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            racun.kreirajNoviRacun(Convert.ToInt32(listaId[listBox1.SelectedIndices[0]]));
            label6.Text = racun.BrojRacuna(Convert.ToInt32(listaId[listBox1.SelectedIndices[0]])).ToString();
            /*kada se doda novi racun, poziva se metoda ispod kako bi se popunio combobox otvorenih
            racuna sa novim racunom */
            listBox1_DoubleClick(new object(), new EventArgs());
        }
        void puniComboRacuna()
        {
           
            DataTable mojaTabela = citajTabeluRacuni();
            comboBox1.DataSource = mojaTabela;
            comboBox1.DisplayMember = "KreiranjeRacuna";
            comboBox1.ValueMember = "Id";
        }
        DataTable citajTabeluRacuni()
        {
           
            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select *from Racuni " +
                "where MusterijaId = "+ listaId[listBox1.SelectedIndices[0]].ToString() , konekcija);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Fill(ds, "Racuni");
            return ds.Tables["Racuni"];
        }
        public static int IdRacuna;
        private static Random random = new Random();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         

            IdRacuna = Convert.ToInt32( comboBox1.SelectedValue.ToString());

            try
            {
                
                konekcija.Open();
                SqlCommand kmnGetId = new SqlCommand("select Id from Musterijas " +
                                                     " where id = " + listaId[listBox1.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetIme = new SqlCommand("select ImePrezime from Musterijas" +
                                                      " where id = " + listaId[listBox1.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetDatumRacuna = new SqlCommand(
                                                        "select KreiranjeRacuna from Racuni " +
                                                        "where MusterijaId = " + listaId[listBox1.SelectedIndices[0]].ToString() +
                                                        " and id = (select max(id) from racuni " +
                                                        "where MusterijaId = "+ listaId[listBox1.SelectedIndices[0]].ToString() +" )", konekcija);
               

                musterija.Id = Convert.ToInt32( kmnGetId.ExecuteScalar());
                musterija.ImePrezime = kmnGetIme.ExecuteScalar().ToString();
                musterija.VremeDolaskaTepiha = Convert.ToDateTime(kmnGetDatumRacuna.ExecuteScalar().ToString());

                dodavanjeTepihaControl1.ucitavanjeTepihaSelektovanogMusterije(musterija, IdRacuna);
                dodavanjeTepihaControl1.Refresh();
                dodavanjeTepihaControl1.Visible = true;
                dodavanjeTepihaControl1.IscitajTabeluTepisiZaMusteriju(IdRacuna);
            

                konekcija.Close();
            }
            catch
            {
                MessageBox.Show("Pogrešno ste izabrali mušteriju.");
            }
            finally
            {
                listBox1.ClearSelected();
                comboBox1.SelectedIndexChanged -= new System.EventHandler(comboBox1_SelectedIndexChanged);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li si siguran da želiš obrisati mušteriju?", "Pitanje", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    musterija.BrisiMusteriju(listaId[listBox1.SelectedIndices[0]]);
                    puniListBoxMusterijama();
                }
            }
            catch 
            {
                MessageBox.Show("Morate selektovati koga želite da obrišete!");
            }
            
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        }
    }
}
