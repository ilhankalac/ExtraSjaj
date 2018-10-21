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
        List<int> idLista;
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
        void iscitavanjeMusterija()
        {
            listBox1.Items.Clear();
            int i = 1;
            idLista = new List<int>();
            foreach (var item in _context.Musterije.ToList())
            {
                listBox1.Items.Add((i++) + ". " + item.ImePrezime + " (" + item.BrojTelefona + " )");
                idLista.Add(item.Id);
            }
        }
        void dodajMusteriju()
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
                MessageBox.Show("Uspešno dodavanje mušterije.", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                iscitavanjeMusterija();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void brisanjeMusterije()
        {
            int idZaBrisanje = idLista[listBox1.SelectedIndices[0]];
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

        private void btnObrisiMusteriju_Click(object sender, EventArgs e)
        {
            brisanjeMusterije();
        }
    }
}
