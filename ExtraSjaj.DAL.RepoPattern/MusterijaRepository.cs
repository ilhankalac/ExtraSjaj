using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class MusterijaRepository :Repository<Musterija>, IMusterijaRepository
    {
        protected readonly ModelContext _context;
        public MusterijaRepository(ModelContext context): base(context)
        {
            _context = context;
        }
        public ModelContext context
        {
            get { return context as ModelContext; }
        }
     
       
        public async Task<List<Musterija>> pretragaMusterija(TextBox textBox)
        {
            /*
             linq koji selektuje one redove koje sadrze karaktere unijete u textbox-u
             pretrazuje po svim atributima u musteriji
            */
            return await _context.Musterije
                                 .Where(x => x.Ime.Contains(textBox.Text) ||
                                 x.Prezime.Contains(textBox.Text) ||
                                 x.BrojTelefona.Contains(textBox.Text) ||
                                 x.Adresa.Contains(textBox.Text))
                                 .ToListAsync();
        }
    }
}
