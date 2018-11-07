using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using ExtraSjaj.Modeli;
using ExtraSjaj.DAL.RepoPattern;
using ExtraSjaj.Common.Interfaces;

namespace ExtraSjaj.Forme
{
    public partial class DodavanjeMusterijeControl : UserControl
    {
        ModelContext _context;
        IUnitOfWork unitOfWork;
        List<int> listaID = new List<int>();
        List<int> listaRacunaID;
        int IDRacunaMusterije;


        public DodavanjeMusterijeControl()
        {
            InitializeComponent();
            _context = new ModelContext();
            unitOfWork = new UnitOfWork(_context);


            // _context.Musterije.LoadAsync();
            //pozivanje asinhrone metode u konstruktoru
            Task.Run(() => this.iscitavanjeMusterija()).Wait();
            dodavanjeTepihaControl1.Visible = false;
        }

        private  void btnDodajMusteriju_Click(object sender, EventArgs e)
        {
             dodajMusteriju();
        }

        private void btnObrisiMusteriju_Click(object sender, EventArgs e)
        {
            brisanjeMusterije();
        }
        private void btnUpdateMusterija_Click(object sender, EventArgs e)
        {
            updateMusterije();
        }
        private async void listaViewRacuna_DoubleClick(object sender, EventArgs e)
        {

            dodavanjeTepihaControl1.Visible = true;
            int racunID = listaRacunaID[listaViewRacuna.SelectedIndices[0]];
            await dodavanjeTepihaControl1.iscitavanjeTepiha(racunID);
            dodavanjeTepihaControl1.Visible = true;

        }
        private async void listBoxMusterija_Click(object sender, EventArgs e)
        {

            try
            {
                string a = listBoxMusterija.SelectedItems[0].ToString();
                if (a == "Prikaži još mušterija...")
                {
                    ucitajNoveMusterije();
                    //return;
                }

                
                await prikazInformacijaMusterijeNakonKlikaNaListBox();
                await  iscitavanjeRacunaSelektovanogMusterije(listaID[listBoxMusterija.SelectedIndices[0]]);
                racunanjeStatistike(listaID[listBoxMusterija.SelectedIndices[0]]);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " Niste korektno izabrali mušteriju.");
            }

        }
        private async void btnKreirajNoviRacun_Click(object sender, EventArgs e)
        {
            await kreiranjeNovogRacuna(listaID[listBoxMusterija.SelectedIndices[0]]);
            await iscitavanjeRacunaSelektovanogMusterije(listaID[listBoxMusterija.SelectedIndices[0]]);
        }
        private void textBoxPretrazivanja_KeyPress(object sender, KeyPressEventArgs e)
        {
            pretragaMusterija();
        }

        private async void iscitavanjeMusterija()
        {

            listBoxMusterija.Items.Clear();
            listaID.Clear();
            int i = 1, r = 0;
            var musterije = (List<Musterija>) (await unitOfWork.Musterije.GetAllAsync());

            var brojMusterija = musterije.Count();

            if (brojMusterija > 10)
                r = brojMusterija - 10;
            else
                r = 0;


            for (int k = brojMusterija - 1; k >= r; k--)
            {
                listBoxMusterija.Items.Add((i++) + ". " + musterije[k].Ime + " " + musterije[k].Prezime + " (" + musterije[k].BrojTelefona + " )");
                listaID.Add(musterije[k].Id);
            }
            listBoxMusterija.Items.Add("Prikaži još mušterija...");

        }
        private async void dodajMusteriju()
        {
            Musterija musterija = new Musterija()
            {
                Ime = txtBoxImePrezime.Text.Substring(0, txtBoxImePrezime.Text.IndexOf(' ')),
                Prezime = txtBoxImePrezime.Text.Substring(txtBoxImePrezime.Text.IndexOf(' ') + 1),
                BrojTelefona = txtBoxBrojTel.Text,
                Adresa = txtBoxAdresa.Text,
                VrijemeKreiranjaMusterije = DateTime.Now
            };
            try
            {
                unitOfWork.Musterije.Add(musterija);
                await unitOfWork.SaveChangesAsync();
                MessageBox.Show("Uspešno dodavavanje mušterije i njenog računa.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                iscitavanjeMusterija();
                kreiranjeRacuna();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private async void brisanjeMusterije()
        {
            int idZaBrisanje = listaID[listBoxMusterija.SelectedIndices[0]];
            Musterija musterijaZaBrisanje = await unitOfWork.Musterije.GetAsync(idZaBrisanje);
            try
            {
                unitOfWork.Musterije.Remove(musterijaZaBrisanje);
                await unitOfWork.SaveChangesAsync();
                MessageBox.Show("Uspešno brisanje mušterije.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                iscitavanjeMusterija();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void kreiranjeRacuna()
        {
            int lastIdMusterije = _context.Musterije.Max(x => x.Id);
            try
            {
                _context.Racuni.Add(new Racun()
                {
                    MusterijaId = lastIdMusterije,
                    BrojTepiha = 0,
                    Placen = false,
                    Vrijednost = 0,
                    VrijemeKreiranjaRacuna = DateTime.Now,
                    VrijemePlacanjaRacuna = Convert.ToDateTime("1.1.2001")
                }
                );
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task kreiranjeNovogRacuna(int IDMusterije)
        {
            try
            {
                _context.Racuni.Add(new Racun()
                {
                    MusterijaId = IDMusterije,
                    BrojTepiha = 0,
                    Placen = false,
                    Vrijednost = 0,
                    VrijemeKreiranjaRacuna = DateTime.Now,
                    VrijemePlacanjaRacuna = Convert.ToDateTime("1.1.2001")
                }
                );
                await unitOfWork.SaveChangesAsync();
                MessageBox.Show("Uspešno napravljen  novi račun!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void updateMusterije()
        {
            int idZaUpdate = listaID[listBoxMusterija.SelectedIndices[0]];
            Musterija stariMusterija = await unitOfWork.Musterije.GetAsync(idZaUpdate);

            try
            {
                stariMusterija.Ime = txtBoxImePrezime.Text.Substring(0, txtBoxImePrezime.Text.IndexOf(' '));
                stariMusterija.Prezime = txtBoxImePrezime.Text.Substring(txtBoxImePrezime.Text.IndexOf(' ') + 1);
                stariMusterija.BrojTelefona = txtBoxBrojTel.Text;
                stariMusterija.Adresa = txtBoxAdresa.Text;
                await unitOfWork.SaveChangesAsync();
                iscitavanjeMusterija();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private async Task  prikazInformacijaMusterijeNakonKlikaNaListBox()
        {
            int idSelektovanogMusterije = listaID[listBoxMusterija.SelectedIndices[0]];
            Musterija stariMusterija = await unitOfWork.Musterije.GetAsync(idSelektovanogMusterije);
            txtBoxImePrezime.Text = stariMusterija.Ime + " " + stariMusterija.Prezime;
            txtBoxAdresa.Text = stariMusterija.Adresa;
            txtBoxBrojTel.Text = stariMusterija.BrojTelefona;
        }
        public async Task iscitavanjeRacunaSelektovanogMusterije(int IDMusterija)
        {
            listaViewRacuna.Items.Clear();
            listaRacunaID = new List<int>();
            int i = 1;
            int j = 0;
            var racuni = await _context.Racuni.Where(x => x.MusterijaId == IDMusterija).ToListAsync();


            foreach (var item in racuni)
            {
                listaViewRacuna.Items.Add((i++) + ". " + item.Vrijednost + " EUR. - " + item.VrijemeKreiranjaRacuna.ToShortDateString());
                IDRacunaMusterije = item.Id;
                listaRacunaID.Add(item.Id);
                if (item.Placen)
                    listaViewRacuna.Items[j].BackColor = Color.Green;
                else
                    listaViewRacuna.Items[j].BackColor = Color.Red;
                j++;
            }
        }



        private async void pretragaMusterija()
        {
            listBoxMusterija.Items.Clear();
            listaID.Clear();
            int i = 1;

            /*
              linq koji selektuje one redove koje sadrze karaktere unijete u textbox-u
              pretrazuje po svim atributima u musteriji
             */
            var rezultatPretrage = await _context.Musterije
                                    .Where(x => x.Ime.Contains(textBoxPretrazivanja.Text) ||
                                    x.Prezime.Contains(textBoxPretrazivanja.Text) ||
                                    x.BrojTelefona.Contains(textBoxPretrazivanja.Text) ||
                                    x.Adresa.Contains(textBoxPretrazivanja.Text))
                                    .ToListAsync();

            foreach (var item in rezultatPretrage)
            {
                listBoxMusterija.Items.Add((i++) + ". " + item.Ime + " " + item.Prezime + " (" + item.BrojTelefona + " )");
                listaID.Add(item.Id);
            }
            if (listBoxMusterija.Items.Count == 0)
                listBoxMusterija.Items.Add("Nema rezultata pretrage: " + textBoxPretrazivanja.Text + ".");

        }
        private void ucitajNoveMusterije()
        {
            listBoxMusterija.Items.RemoveAt(listBoxMusterija.Items.Count - 1);
            int j = listBoxMusterija.Items.Count, i = listBoxMusterija.Items.Count + 1, r;
            var musterije = _context.Musterije.ToList();
            r = musterije.Count - listBoxMusterija.Items.Count; ;


            /*
             ako budes htio da dodajes feature da se izabere na aplikaciji
             koliko da  se redova cita iz baze, samo promjenis r - 5 u (r - Convert.toInt32(textBox.Text));
             */
            for (int k = r - 1; k >= r - 10; k--)
            {
                if (k != -1)
                {
                    listBoxMusterija.Items.Add((i++) + ". " + musterije[k].Ime + " " + musterije[k].Prezime + " (" + musterije[k].BrojTelefona + " )");
                    listaID.Add(musterije[k].Id);

                }
                else break;
            }
            listBoxMusterija.Items.Add("Prikaži još mušterija...");
        }



        private void racunanjeStatistike(int IDMusterije)
        {
            var racuniMusterije = _context.Racuni.
                                  Where(x => x.MusterijaId == IDMusterije).ToList();

            labelUkupnogNovca.Visible = true;
            labelOpranihTepiha.Visible = true;
            labelUkupnogNovca.Text = "Total profit: ";
            labelOpranihTepiha.Text = "Broj opranih tepiha: ";
            labelUkupnogNovca.Text += racuniMusterije.Sum(x => x.Vrijednost).ToString() + " EUR.";
            labelOpranihTepiha.Text += racuniMusterije.Sum(x => x.BrojTepiha).ToString() + ".";


            int i = 1;
            chartRacuni.Visible = true;
            chartRacuni.Series["Racuni"].Points.Clear();
            foreach (var racun in racuniMusterije)
                chartRacuni.Series["Racuni"].Points.AddXY(i++, racun.Vrijednost);





        }
    }
}