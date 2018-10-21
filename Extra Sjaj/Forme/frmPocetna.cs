using ExtraSjaj.Forme;
using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        ModelContext _context;
        List<int> listaID;
        public frmPocetna()
        {
            InitializeComponent();
            _context = new ModelContext();
            _context.Racuni.Load();
            dodavanjeTepihaControl1.Visible = false;
            this.musterijasBindingSource3.DataSource = _context.Musterije.Local.ToBindingList();
            btnHomePage.Visible = false;
            dodavanjeMusterijeControl1.Visible = false;
            iscitavanjeRacunaMusterija();
        }
        public void iscitavanjeRacunaMusterija()
        {
            listaRacuna.Items.Clear();
            int i = 1;
            int j = 0;
            listaID = new List<int>();
            foreach (var item in _context.Racuni.ToList())
            {
                listaRacuna.Items.Add((i++) + ". " + item.Musterija.ImePrezime +" = "+item.Vrijednost+ " EUR. - " + item.VrijemeKreiranjaRacuna.ToShortDateString());
                listaID.Add(item.Id);
                if (item.Placen)
                    listaRacuna.Items[j].BackColor = Color.Green;
                else
                    listaRacuna.Items[j].BackColor = Color.Red;
                j++;
            }
        }
     




        private void Form1_Load(object sender, EventArgs e)
        {
            iscitavanjeRacunaMusterija();
        }
        private void prikaziOpcijeSaMusterijama(object sender, EventArgs e)
        {
            btnHomePage.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = true;
            listaRacuna.Visible = false;
            button6.Visible = false;
            label3.Visible = false;
            cmbBrojaRacuna.Visible = false;
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
            timer1.Enabled = false;
            listaRacuna.Width = 490;
            listaRacuna.Height = 603;
            iscitavanjeRacunaMusterija();
            dodavanjeMusterijeControl1.Visible = false;
            listaRacuna.Visible = true;
        }

        private void listaRacuna_DoubleClick(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            int racunID = listaID[listaRacuna.SelectedIndices[0]];
            dodavanjeTepihaControl1.iscitavanjeTepiha(racunID);
            dodavanjeTepihaControl1.Visible = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listaRacuna.Width < 0)
                this.timer1.Enabled = false;
            else
                listaRacuna.Width -= 25;
        }
    }
    }
