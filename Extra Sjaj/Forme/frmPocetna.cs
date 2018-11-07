using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj
{
    public partial class frmPocetna : Form
    {
        ModelContext _context;
        List<int> listaID = new List<int>();
        public frmPocetna()
        {
            InitializeComponent();
            _context = new ModelContext();
            dodavanjeTepihaControl1.Visible = false;
            this.musterijasBindingSource3.DataSource = _context.Musterije.Local.ToBindingList();
            btnHomePage.Visible = false;
            dodavanjeMusterijeControl1.Visible = false;

            //pozivanje asinhrone metode u konstruktoru
            Task.Run(() =>this.iscitavanjeRacunaMusterija()).Wait(); 
          
           

        }
        public async Task iscitavanjeRacunaMusterija()
        {
            listaRacuna.Items.Clear();
            listaID.Clear();
            int i = 1, j = 0, r = 0;
            var racuni = await _context.Racuni.ToListAsync();
            var brojRacuna = _context.Racuni.ToList().Count();

            if (brojRacuna > 5)
                r = brojRacuna - 5;
            else
                r = 0;
               
            for (int k = brojRacuna - 1; k >= r; k--)
            {
                listaRacuna.Items.Add((i++) + ". " + racuni[k].Musterija.Ime + " " + racuni[k].Musterija.Prezime + " = " + racuni[k].Vrijednost + " EUR. - " + racuni[k].VrijemeKreiranjaRacuna.ToShortDateString());
                listaID.Add(racuni[k].Id);
                if (racuni[k].Placen)
                    listaRacuna.Items[j].BackColor = Color.Green;
                else
                    listaRacuna.Items[j].BackColor = Color.Red;
                j++;
            }
            listaRacuna.Items.Add("Prikaži još računa...");

        }
     
        private async void Form1_Load(object sender, EventArgs e)
        {
            await iscitavanjeRacunaMusterija();
        }
        private void prikaziOpcijeSaMusterijama(object sender, EventArgs e)
        {
           
            _context = new ModelContext();
            _context.Musterije.LoadAsync();
            _context.Racuni.LoadAsync();
            btnHomePage.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            dodavanjeMusterijeControl1.Visible = true;
            listaRacuna.Visible = false;
            button6.Visible = false;
            label3.Visible = false;
            cmbBrojaRacuna.Visible = false;
            panel4.Visible = false;
         
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

        private async void btnRacuni_Click(object sender, EventArgs e)
        {
            _context = new ModelContext();
            await _context.Racuni.LoadAsync();
            timer1.Enabled = false;
            listaRacuna.Width = 490;
            listaRacuna.Height = 603;
            await iscitavanjeRacunaMusterija();
            dodavanjeMusterijeControl1.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            listaRacuna.Visible = true;
            panel4.Visible = true;
        }

        private async void listaRacuna_DoubleClick(object sender, EventArgs e)
        {
            button6.Visible = false;
            panel4.Visible = false;
            label3.Visible = false;
            cmbBrojaRacuna.Visible = false;
            this.timer1.Enabled = true;
            int racunID = listaID[listaRacuna.SelectedIndices[0]];
            await dodavanjeTepihaControl1.iscitavanjeTepiha(racunID);
            dodavanjeTepihaControl1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (listaRacuna.Width < 0)
                this.timer1.Enabled = false;
            else
                listaRacuna.Width -= 35;
        }

        private void listaRacuna_Click(object sender, EventArgs e)
        {
            //funkcija koja uzima tacan tekst za prosirivanje liste racuna na klik
            string a = listaRacuna.SelectedItems[0].ToString().Substring(15, 21);
            if (a == "Prikaži još računa...")
                ucitajNoveRacune();

        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selekcijaRacunaPoDatumu();
        }
      
        private async void ucitajNoveRacune()
        {
            listaRacuna.Items.RemoveAt(listaRacuna.Items.Count - 1);
            int j = listaRacuna.Items.Count, i = listaRacuna.Items.Count + 1, r;
            var racuni = await _context.Racuni.ToListAsync();
            r = racuni.Count - listaRacuna.Items.Count; ;


            /*
             ako budes htio da dodajes feature da se izabere na aplikaciji
             koliko da  se redova cita iz baze, samo promjenis r - 5 u (r - Convert.toInt32(textBox.Text));
             */
            for (int k = r-1; k >= r-5; k--)
            {
                if (k != -1)
                {
                    listaRacuna.Items.Add((i++) + ". " + racuni[k].Musterija.Ime +" " + racuni[k].Musterija.Prezime + " = " + racuni[k].Vrijednost + " EUR. - " + racuni[k].VrijemeKreiranjaRacuna.ToShortDateString());
                    listaID.Add(racuni[k].Id);
                    if (racuni[k].Placen)
                        listaRacuna.Items[j].BackColor = Color.Green;
                    else
                        listaRacuna.Items[j].BackColor = Color.Red;
                    j++;
                }
                else break;
            }
            listaRacuna.Items.Add("Prikaži još računa...");
        }
    
        private async void selekcijaRacunaPoDatumu()
        {

            int j = 0, i = 1;

            /*
                 linq sa kojim se prikazuje lista racuna 
                 selektovanog datuma na kalendaru, po danu, mjesecu i godini              
            */
            var racuni = await _context.Racuni
                        .Where(x => x.VrijemeKreiranjaRacuna.Day == monthCalendar1.SelectionRange.Start.Day)
                        .Where(x => x.VrijemeKreiranjaRacuna.Month == monthCalendar1.SelectionRange.Start.Month)
                        .Where(x => x.VrijemeKreiranjaRacuna.Year == monthCalendar1.SelectionRange.Start.Year)
                        .ToListAsync();


            statistikaNaDnevnomNivou(racuni);

            listaRacuna.Items.Clear();
            for (int k = 0; k < racuni.Count; k++)
            {
                listaRacuna.Items.Add((i++) + ". " + racuni[k].Musterija.Ime + " " + racuni[k].Musterija.Prezime + " = " + racuni[k].Vrijednost + " EUR. - " + racuni[k].VrijemeKreiranjaRacuna.ToShortDateString());
                listaID.Add(racuni[k].Id);
                if (racuni[k].Placen)
                    listaRacuna.Items[j].BackColor = Color.Green;
                else
                    listaRacuna.Items[j].BackColor = Color.Red;
                j++;
            }
        }
        private void statistikaNaDnevnomNivou(List<Racun> racuni)
        {
            label4.Text = "Potencijalna zarada: " + racuni.Sum(n => n.Vrijednost).ToString() + " EUR.";
            label5.Text = "Zarada: " + racuni.Where(n => n.Placen == true).
                                        Sum(n => n.Vrijednost).ToString() + " EUR.";

            label6.Text = "Broj opranih tepiha: " + racuni.Sum(n => n.BrojTepiha).ToString() + ".";

        }


    }
}
    
