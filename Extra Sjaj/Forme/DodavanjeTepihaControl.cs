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
        }
        private void btnDodajTepih_Click(object sender, EventArgs e)
        {
            dodajTepih();
        }
        private void listBoxTepiha_DoubleClick(object sender, EventArgs e)
        {
            brisanjeTepiha();
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
                //ovde ces trebati da dodas jos sa cijenom da se mnozi
                updateVrijednostiRacuna();
                iscitavanjeTepiha(racunID);
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
                    updateVrijednostiRacuna();
                    iscitavanjeTepiha(racunID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateVrijednostiRacuna()
        {
            var racun = _context.Racuni.Where(x => x.Id == racunID).SingleOrDefault();
            var sviTepisi = _context.Tepisi.Where(x => x.RacunId == racunID).ToList();
            racun.Vrijednost = 0;
            foreach (var item in sviTepisi)
                racun.Vrijednost += item.Kvadratura;
            _context.SaveChanges();
        }
        void sakrijObjekteNaKontroli()
        {
            txtBoxSirina.Visible = false;
            txtBoxDuzina.Visible = false;
            btnDodajTepih.Visible = false;
            btnNaplati.Visible = false;
            comboBox1.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
            textBox3.Visible = false;
        }
        void otkrijObjekteNaKontroli()
        {
            txtBoxSirina.Visible = true;
            txtBoxDuzina.Visible = true;
            btnDodajTepih.Visible = true;
            btnNaplati.Visible = true;
            comboBox1.Visible = true;
            label4.Visible = true;
            label3.Visible = true;
            label7.Visible = true;
            textBox3.Visible = true;
        }
        void resetujObjekte()
        {
            listBoxTepiha.Items.Clear();
            txtBoxSirina.Clear();
            txtBoxDuzina.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
        }
    }
}
