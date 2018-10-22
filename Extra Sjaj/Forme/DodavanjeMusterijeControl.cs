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
    public partial class DodavanjeMusterijeControl : UserControl
    {
        ModelContext _context;
        List<int> listaID;
        int IDRacunaMusterije;
        public DodavanjeMusterijeControl()
        {
            InitializeComponent();
            _context = new ModelContext();
            _context.Musterije.Load();
            iscitavanjeMusterija();
            
        }

        private void btnDodajMusteriju_Click(object sender, EventArgs e)
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
        private void listBoxMusterija_Click(object sender, EventArgs e)
        {
            try
            {
                prikazInformacijaMusterijeNakonKlikaNaListBox();
                iscitavanjeRacunaSelektovanogMusterije(listaID[listBoxMusterija.SelectedIndices[0]]);
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message+" Niste korektno izabrali mušteriju.");
            }
           
        }
       
        private  void iscitavanjeMusterija()
        {
            listBoxMusterija.Items.Clear();
            int i = 1;
            listaID = new List<int>();
            foreach (var item in _context.Musterije.ToList())
            {
                listBoxMusterija.Items.Add((i++) + ". " + item.ImePrezime + " (" + item.BrojTelefona + " )");
                listaID.Add(item.Id);
            }

        }
        private void dodajMusteriju()
        {
            Musterija musterija = new Musterija()
            {
                ImePrezime = txtBoxImePrezime.Text,
                BrojTelefona = txtBoxBrojTel.Text,
                Adresa = txtBoxAdresa.Text,
                VrijemeKreiranjaMusterije = DateTime.Now
            };
            try
            {
                _context.Musterije.Add(musterija);
                _context.SaveChanges();
                MessageBox.Show("Uspešno dodavavanje mušterije i njenog računa.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                iscitavanjeMusterija();
                kreiranjeRacuna();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       private void brisanjeMusterije()
        {
            int idZaBrisanje = listaID[listBoxMusterija.SelectedIndices[0]];
            Musterija musterijaZaBrisanje = _context.Musterije.SingleOrDefault(x => x.Id == idZaBrisanje);
            try
            {
                _context.Musterije.Remove(musterijaZaBrisanje);
                _context.SaveChanges();
                MessageBox.Show("Uspešno brisanje mušterije.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                iscitavanjeMusterija();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void kreiranjeRacuna()
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
                    VrijemeKreiranjaRacuna = DateTime.Now
                }
                );
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateMusterije()
        {
            int idZaUpdate = listaID[listBoxMusterija.SelectedIndices[0]];
            Musterija stariMusterija = _context.Musterije.SingleOrDefault(x => x.Id == idZaUpdate);

            try
            {
                stariMusterija.ImePrezime = txtBoxImePrezime.Text;
                stariMusterija.BrojTelefona = txtBoxBrojTel.Text;
                stariMusterija.Adresa = txtBoxAdresa.Text;
                _context.SaveChanges();
                iscitavanjeMusterija();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        void prikazInformacijaMusterijeNakonKlikaNaListBox()
        {
            int idSelektovanogMusterije = listaID[listBoxMusterija.SelectedIndices[0]];
            Musterija stariMusterija = _context.Musterije.SingleOrDefault(x => x.Id == idSelektovanogMusterije);
            txtBoxImePrezime.Text = stariMusterija.ImePrezime;
            txtBoxAdresa.Text = stariMusterija.Adresa;
            txtBoxBrojTel.Text = stariMusterija.BrojTelefona;
        }
        public void iscitavanjeRacunaSelektovanogMusterije(int IDMusterija)
        {
            listaViewRacuna.Items.Clear();
            int i = 1;
            int j = 0;
            foreach (var item in _context.Racuni.ToList().Where(x=> x.MusterijaId==IDMusterija))
            {
                listaViewRacuna.Items.Add((i++) +". "+ item.Vrijednost + " EUR. - " + item.VrijemeKreiranjaRacuna.ToShortDateString());
                IDRacunaMusterije = item.Id;
                if (item.Placen)
                    listaViewRacuna.Items[j].BackColor = Color.Green;
                else
                    listaViewRacuna.Items[j].BackColor = Color.Red;
                j++;
            }
        }
     
    }
}
