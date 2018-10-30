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
using System.Data.Entity;

namespace ExtraSjaj.Forme
{
    public partial class DodavanjeTepihaControl : UserControl
    {

        ModelContext _context;
        List<int> idLista;
        int racunID;
        public DodavanjeTepihaControl()
        {
            InitializeComponent();
            _context = new ModelContext();
            _context.Tepisi.Load();
          
        }


        public void iscitavanjeTepiha(int racunID)
        {
            this.racunID = racunID;
            listBoxTepiha.Items.Clear();
            int i = 1;
            idLista = new List<int>();
            foreach (var item in _context.Tepisi.ToList().Where(x=> x.RacunId == racunID))
            {
                listBoxTepiha.Items.Add((i++)+". "+item.Sirina +" X " +item.Duzina+" = "+item.Kvadratura + "m²");
                idLista.Add(item.Id);
            }
            informacijeORacunu();
            iscrtajTepihe();
        }
        private void btnDodajTepih_Click(object sender, EventArgs e)
        {
            dodajTepih();
        }
        private void listBoxTepiha_DoubleClick(object sender, EventArgs e)
        {
            brisanjeTepiha();
        }
        private void comboBoxCijena_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateRacun();
        }
        private void btnNaplati_Click(object sender, EventArgs e)
        {
            naplati();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void dodajTepih()
        {
            Tepih tepih = new Tepih()
            {
                Duzina = Convert.ToSingle( txtBoxDuzina.Text),
                Sirina = Convert.ToSingle(txtBoxSirina.Text),
                Kvadratura = Convert.ToSingle(txtBoxSirina.Text) * Convert.ToSingle(txtBoxDuzina.Text),
                RacunId = racunID
            };
            try
            {

                //dodavanje tepiha u tabeli tepisi
                _context.Tepisi.Add(tepih);
                _context.SaveChanges();
                //update vrijednosti racuna u tabeli racuni
                updateRacun();
                iscitavanjeTepiha(racunID);
                iscrtajTepihe();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void brisanjeTepiha()
        {
            int idZaBrisanje = idLista[listBoxTepiha.SelectedIndices[0]];
            Tepih tepihZaBrisanje = _context.Tepisi.SingleOrDefault(x => x.Id == idZaBrisanje);
            try
            {
                DialogResult dialogResult = MessageBox.Show("Da li si siguran da želiš da obrišeš ovaj tepih?", "Pitanje", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    _context.Tepisi.Remove(tepihZaBrisanje);
                    _context.SaveChanges();
                    MessageBox.Show("Uspešno brisanje tepiha.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateRacun();
                    iscitavanjeTepiha(racunID);
                    iscrtajTepihe();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void informacijeORacunu()
        {

            var racun = _context.Racuni.FirstOrDefault(x => x.Id==racunID);
            var musterija = _context.Musterije.FirstOrDefault(x => x.Id == racun.MusterijaId);


            labelRacun.Text = "Račun: ";
            labelPlaceno.Text = "Plaćeno: ";

            labelRacun.Text +=" "+ racun.Vrijednost+" EUR.";
            labelImePrezime.Text = musterija.ImePrezime;
            labelPlaceno.Text +=Convert.ToString(racun.Placen);

            textBoxNaplate.Text = racun.Vrijednost.ToString();
        }

        private void updateRacun()
        {
            var racun = _context.Racuni.Where(x => x.Id == racunID).SingleOrDefault();
            double sumaKvadrature = 0;

            //linq koji prolazi kroz sve tepihe selektovanog racuna i racuna sumu kvadrature
            foreach (var tepih in _context.Tepisi.Where(x => x.RacunId == racunID).ToList())
                sumaKvadrature += tepih.Kvadratura;

            try
            {
                racun.Vrijednost = Math.Round((Convert.ToSingle(comboBoxCijena.Text) * sumaKvadrature), 2);
                _context.SaveChanges();
                informacijeORacunu();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void naplati()
        {
            var racun = _context.Racuni.Where(x => x.Id == racunID).SingleOrDefault();
            try
            {
                DialogResult dialogResult = MessageBox.Show("Da li si siguran da je mušterija platio?", "Poruka", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if ((dialogResult == DialogResult.Yes) && Convert.ToDouble(textBoxNaplate.Text) <= racun.Vrijednost && Convert.ToDouble(textBoxNaplate.Text) > 0)
                {
                    //ne radi ti ovaj if matematicki kako treba
                    if ((racun.Vrijednost - Convert.ToSingle(textBoxNaplate.Text) == 0))
                        racun.Placen = true;
                    else
                        racun.Vrijednost -= Convert.ToSingle(textBoxNaplate.Text);


                    _context.SaveChanges();
                    MessageBox.Show("Uspešno naplaćeno.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToDouble(textBoxNaplate.Text) > racun.Vrijednost || Convert.ToDouble(textBoxNaplate.Text) < 0)
                {
                    MessageBox.Show("Ispravno unesi koliko је mušterija ostavio novca.(ne mozeš uneti negativan broj, niti više od njegovog računa.");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
        
        private void iscrtajTepihe()
        {

            int top = 50, left = 50, k = 0, i = 0;
            var tepisi = _context.Tepisi.Where(x => x.RacunId == racunID).ToList();
            /*petlja koja brise sva dugmad na panelu, kako bismo obezbijedili
             da nakon  brisanja krece ispocetka sa iscrtavanjem
            */
            foreach (var button in panel3.Controls.OfType<Button>())
                panel3.Controls.Remove(button);

            foreach (var tepih in tepisi)
            {
                /*if sa kojim se pomera u novi red iscrtavanje tepiha nakon svakog petog tepiha
                  vrijednosti su izabrane otprilike, tj na osnovu mojih nekih procjena
                */
                if (i %5 == 0 && i !=0)
                {
                    k++;
                    left = 50;
                    top = 50 + (k * 120);               
                }
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Width = Convert.ToInt32( tepih.Sirina)*25;
                button.Height = Convert.ToInt32(tepih.Duzina)*25;
                button.Text =  tepih.Sirina +" X "+ tepih.Duzina.ToString();
                button.BackColor = Color.OrangeRed;
                button.Enabled = false;
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Popup;
                panel3.Controls.Add(button);
                left += 100;
                i++;
            }

           
        }
        void sakrijObjekteNaKontroli()
        {
            txtBoxSirina.Visible = false;
            txtBoxDuzina.Visible = false;
            btnDodajTepih.Visible = false;
            btnNaplati.Visible = false;
            comboBoxCijena.Visible = false;
            label4.Visible = false;
            label3.Visible = false;

        }
        void otkrijObjekteNaKontroli()
        {
            txtBoxSirina.Visible = true;
            txtBoxDuzina.Visible = true;
            btnDodajTepih.Visible = true;
            btnNaplati.Visible = true;
            comboBoxCijena.Visible = true;
            label4.Visible = true;
            label3.Visible = true;

        }
        void resetujObjekte()
        {
            listBoxTepiha.Items.Clear();
            txtBoxSirina.Clear();
            txtBoxDuzina.Clear();
        }

       
    }
}
