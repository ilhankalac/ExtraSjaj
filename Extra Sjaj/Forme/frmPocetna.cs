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
        List<int> listaID = new List<int>();
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
            kalendar();
            prikrijLabele();
           

        }
        public void iscitavanjeRacunaMusterija()
        {
            listaRacuna.Items.Clear();
            listaID.Clear();
            int i = 1, j = 0, r = 0;
            var racuni = _context.Racuni.ToList();
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
     
        private void Form1_Load(object sender, EventArgs e)
        {
            iscitavanjeRacunaMusterija();
        }
        private void prikaziOpcijeSaMusterijama(object sender, EventArgs e)
        {
           
            _context = new ModelContext();
            _context.Musterije.Load();
            _context.Racuni.Load();
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

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            _context = new ModelContext();
            _context.Racuni.Load();
            timer1.Enabled = false;
            listaRacuna.Width = 490;
            listaRacuna.Height = 603;
            iscitavanjeRacunaMusterija();
            dodavanjeMusterijeControl1.Visible = false;
            dodavanjeTepihaControl1.Visible = false;
            listaRacuna.Visible = true;
            panel4.Visible = true;
        }

        private void listaRacuna_DoubleClick(object sender, EventArgs e)
        {
            button6.Visible = false;
            panel4.Visible = false;
            label3.Visible = false;
            cmbBrojaRacuna.Visible = false;
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
                listaRacuna.Width -= 35;
        }

        private void listaRacuna_Click(object sender, EventArgs e)
        {
            //funkcija koja uzima tacan tekst za prosirivanje liste racuna na klik
            string a = listaRacuna.SelectedItems[0].ToString().Substring(15, 21);
            if (a == "Prikaži još računa...")
                ucitajNoveRacune();

        }
        private void btnIzaberiDatum_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Button clickedButton = new Button();
            int j = 0, i = 1, brojacProlaza = 0;
            List<DateTime> listaprvihDatuma = new List<DateTime>();

            //foreach sa kojim se uzima vrijednost sa kliknutog dugmeta koje je dinamicki napravljen
            foreach (var button in panel4.Controls.OfType<Button>())
            {
                //if koji uzima vrijednosti datuma  prvog reda dana dinamickog kalendara
                if(brojacProlaza < 7)
                {
                    listaprvihDatuma.Add(Convert.ToDateTime( button.Tag));
                    brojacProlaza++;
                }

                if (btnSender == button)
                    clickedButton = button;
            }

            ispisiDaneUKalendaru(listaprvihDatuma);


            DateTime date = Convert.ToDateTime(clickedButton.Tag);
            //linq sa kojim se selektuju racuni izabranog dana u datumu
            var racuni = _context.Racuni
                        .Where(x => x.VrijemeKreiranjaRacuna.Day == date.Day).ToList();


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

        
        private void ucitajNoveRacune()
        {
            listaRacuna.Items.RemoveAt(listaRacuna.Items.Count - 1);
            int j = listaRacuna.Items.Count, i = listaRacuna.Items.Count + 1, r;
            var racuni = _context.Racuni.ToList();
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
        private void prikrijLabele()
        {

            label9.Text = "";
            label4.Text = "";
            label10.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
        }
        private void kalendar()
        {
            int top = 30, left = 30, k = 0, i =0;

            /*petlja koja brise sva dugmad na panelu, kako bismo obezbijedili
             da nakon  brisanja krece ispocetka sa iscrtavanjem
            */
            foreach (var button in panel4.Controls.OfType<Button>())
                panel4.Controls.Remove(button);

            foreach (DateTime dan in EachDay(DateTime.Now.AddDays(-30), DateTime.Now))
            {
                /*if sa kojim se pomera u novi red iscrtavanje tepiha nakon svakog petog tepiha
                 vrijednosti su izabrane otprilike, tj na osnovu mojih nekih procjena
               */
                if (i % 7 == 0 && i != 0)
                {
                    k++;
                    left = 30;
                    top = 30 + (k * 50);
                }
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Width = 30;
                button.Height = 30;
                button.Text = dan.Day.ToString();
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Popup;
                button.BackColor = Color.White;
                button.Tag = dan;
                button.Click += new EventHandler(btnIzaberiDatum_Click);
                panel4.Controls.Add(button);
                left += 50;
                i++;
            }
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        private void ispisiDaneUKalendaru(List<DateTime> listaPrvihDatuma)
        {
            //ispis prva 3 slova imena dana po kolonama dinamickih buttona

            label9.Text = listaPrvihDatuma[0].DayOfWeek.ToString().Substring(0, 3);
            label4.Text = listaPrvihDatuma[1].DayOfWeek.ToString().Substring(0, 3);
            label10.Text = listaPrvihDatuma[2].DayOfWeek.ToString().Substring(0, 3);
            label5.Text = listaPrvihDatuma[3].DayOfWeek.ToString().Substring(0, 3);
            label6.Text = listaPrvihDatuma[4].DayOfWeek.ToString().Substring(0, 3);
            label7.Text = listaPrvihDatuma[5].DayOfWeek.ToString().Substring(0, 3);
            label8.Text = listaPrvihDatuma[6].DayOfWeek.ToString().Substring(0, 3);
        }
        
    }
}
    
