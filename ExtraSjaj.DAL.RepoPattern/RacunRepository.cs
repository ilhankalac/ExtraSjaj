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
    public class RacunRepository : Repository<Racun>, IRacunRepository
    {
        protected readonly ModelContext _context;
        public RacunRepository(ModelContext context) : base(context)
        {
            _context = context;
        }
        public ModelContext context
        {
            get { return context as ModelContext; }
          
        }

        public int ukupanBrojRacuna()
        {
            return _context.Racuni.ToList().Count();
        }


        public async Task<List<Racun>> racuniSelektovanogDatuma(MonthCalendar monthCalendar1)
        {
            /*
                linq sa kojim se prikazuje lista racuna 
                selektovanog datuma na kalendaru, po danu, mjesecu i godini              
           */
            return await _context.Racuni
                        .Where(x => x.VrijemeKreiranjaRacuna.Day == monthCalendar1.SelectionRange.Start.Day)
                        .Where(x => x.VrijemeKreiranjaRacuna.Month == monthCalendar1.SelectionRange.Start.Month)
                        .Where(x => x.VrijemeKreiranjaRacuna.Year == monthCalendar1.SelectionRange.Start.Year)
                        .ToListAsync();
        }

        public async Task<List<Racun>> racuniMusterije(int IDMusterije)
        {
            return await _context.Racuni.Where(x => x.MusterijaId == IDMusterije).ToListAsync();
        }


        public void statistikaRacunaNaDnevnomNivou(List<Racun> racuni, Label[] labels)
        {
            labels[0].Text = "Potencijalna zarada: " + racuni.Sum(n => n.Vrijednost).ToString() + " EUR.";
            labels[1].Text = "Zarada: " + racuni.Where(n => n.Placen == true).
                                        Sum(n => n.Vrijednost).ToString() + " EUR.";
            labels[2].Text = "Broj opranih tepiha: " + racuni.Sum(n => n.BrojTepiha).ToString() + ".";
        }




    }
}
