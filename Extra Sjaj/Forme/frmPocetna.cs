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
            listaRacuna.Visible = false;
        }

        public Musterija musterija;
        public Racun Racun;
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        private SqlDataAdapter da = null;
        bool ovogMjeseca = false;
        List<int> listaIdRacuna = new List<int>();
        List<int> listaIdMusterija = new List<int>();
    

        private void Form1_Load(object sender, EventArgs e)
        {
            musterija = new Musterija();
       
            label1.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);
            label1.Text +="/"+ DateTime.Now.Year.ToString();
            dodavanjeMusterijeControl1.Visible = false;
            btnHomePage.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = false;
            button6.Visible = false;

        }
        private void prikaziOpcijeSaMusterijama(object sender, EventArgs e)
        {
            btnHomePage.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = true;
            listaRacuna.Visible = false;
            button6.Visible = false;
        }

        private void prikaziStatistikuFirme(object sender, EventArgs e)
        {
            btnHomePage.Visible = true;
        }

        private void closeForm(object sender, EventArgs e)
        {
            this.Close();
        }


        private void homePageButton(object sender, EventArgs e)
        {
            dodavanjeMusterijeControl1.Visible = false;
            btnHomePage.Visible = false;
            dodavanjeMusterijeControl1.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            listaRacuna.Items.Clear();
                
            listaRacuna.Visible = true;
            Racun = new Racun();
            int i = 0;
            string idMusterije = "";
            
            foreach (var item in Racun.recnikRacuna(ovogMjeseca))
            {
                //funkcija koja mi vraca rezultat id-a musterije poslije karaktera '='
                idMusterije = item.Value.Substring( item.Value.IndexOf("=")+1);
                listaIdMusterija.Add(Convert.ToInt32(idMusterije));
                listaRacuna.Items.Add(item.Value);
                listaIdRacuna.Add(item.Key);
                if (item.Value.Contains("True"))
                    listaRacuna.Items[i].BackColor = Color.Green;
                else
                    listaRacuna.Items[i].BackColor = Color.Red;
                i++;
            }
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ovogMjeseca)
            {
                ovogMjeseca = false;
                button6.BackColor = Color.Gray;
            }

            else
            {
                button6.BackColor = Color.Green;
                ovogMjeseca = true;
            }
                
            btnRacuni_Click(new object(), new EventArgs());
        }

        private void listaRacuna_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listaRacuna_DoubleClick(object sender, EventArgs e)
        {
            int IdRacuna = listaIdRacuna[listaRacuna.SelectedIndices[0]];

            try
            {
                konekcija.Open();
                SqlCommand kmnGetStatusRacuna = new SqlCommand("select placen from racuni where id = " + IdRacuna, konekcija);

              
                SqlCommand kmnGetIme = new SqlCommand("select ImePrezime from Musterijas" +
                                                      " where id = " + listaIdMusterija[listaRacuna.SelectedIndices[0]].ToString(), konekcija);
                SqlCommand kmnGetDatumRacuna = new SqlCommand(
                                                        "select KreiranjeRacuna from Racuni " +
                                                        "where MusterijaId = " + listaIdMusterija[listaRacuna.SelectedIndices[0]].ToString() +
                                                        " and id = (select max(id) from racuni " +
                                                        "where MusterijaId = " + listaIdMusterija[listaRacuna.SelectedIndices[0]].ToString() + " )", konekcija);

                musterija.Id = listaIdMusterija[listaRacuna.SelectedIndices[0]];
                musterija.ImePrezime = kmnGetIme.ExecuteScalar().ToString();
                musterija.VremeDolaskaTepiha = Convert.ToDateTime(kmnGetDatumRacuna.ExecuteScalar().ToString());

                dodavanjeTepihaControl1.ucitavanjeProfilaTepiha(musterija, IdRacuna, Convert.ToBoolean(kmnGetStatusRacuna.ExecuteScalar()));
                dodavanjeTepihaControl1.Refresh();
                dodavanjeTepihaControl1.Visible = true;
                dodavanjeTepihaControl1.IscitajTabeluTepisiZaMusteriju(IdRacuna);

            }
            catch
            {
                MessageBox.Show("Pogrešno ste izabrali mušteriju.");
            }
            finally
            {
                listaRacuna.Clear();

                konekcija.Close();

            }
        }

      
    }
    }
