using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class RacunRepository : Repository<Racun>, IRacunRepository
    {
        protected readonly ExtraSjajContext _context;

        public RacunRepository(ExtraSjajContext context) : base(context)
        {
            _context = context;
        }

        public ExtraSjajContext context
        {
            get { return context as ExtraSjajContext; }
        }

        public async Task<IEnumerable<Racun>> getRacuniByMusterijaId(int MusterijaId){

            return await _context.Racuni.Where(x => x.MusterijaId == MusterijaId).OrderByDescending(x=> x.Id).ToListAsync();
        }

        
        public  void tepihAkcija(Tepih tepih)
        {
            var stariRacun = _context.Racuni.Where(x => x.Id == tepih.RacunId).FirstOrDefault();
            //you will make this variable below optional
            double cijena = 1;


            stariRacun.BrojTepiha = _context.Tepisi.Count(x => x.RacunId == stariRacun.Id);
            stariRacun.Vrijednost = Math.Round((ukupnaKvadratura(stariRacun.Id) * cijena),2);

            _context.Racuni.Update(stariRacun);

            _context.SaveChanges();
        }

        double ukupnaKvadratura(int RacunId)
        {
            return _context.Tepisi.Where(x => x.RacunId == RacunId).Sum(x => x.Kvadratura);
        }

        public double zaradaNaOdabranomMesecu(DateTime time)
        {
            return _context.Racuni.Where
                    (
                           x => x.Placen == 1 && x.VrijemePlacanjaRacuna.Month == time.Month &&
                           x.VrijemePlacanjaRacuna.Month == time.Month)
                          .DefaultIfEmpty()
                          .Sum(x => x.Vrijednost
                    );
        }

        public double zaradaOdabraneGodine(DateTime time)
        { 
            return _context.Racuni.Where(x => x.Placen == 1 && x.VrijemePlacanjaRacuna.Year == time.Year)
                  .DefaultIfEmpty()
                  .Sum(x => x.Vrijednost);
        }

        public double prosecnaMesecnaZarada(DateTime time)
        {
            return _context.Racuni.Where
                    (
                           x => x.Placen == 1 && x.VrijemePlacanjaRacuna.Month == time.Month &&
                           x.VrijemePlacanjaRacuna.Year == time.Year)
                           .DefaultIfEmpty() 
                          .Average(x => x.Vrijednost
                    );
        }


        public double prosecnaGodisnjaZarada(DateTime time)
        {
            return _context.Racuni.Where(x => x.Placen == 1 && x.VrijemePlacanjaRacuna.Year == time.Year)
                   .DefaultIfEmpty()
                   .Average(x => x.Vrijednost);
        }
        public void naplacivanje(int id)
        {
            var racun = _context.Racuni.Where(x => x.Id == id).FirstOrDefault();

            racun.Placen = 1;
            racun.VrijemePlacanjaRacuna = DateTime.Now;

            _context.Racuni.Update(racun);

            _context.SaveChanges();
        }

        public object statistika()
        {
            //statistic grouped by years and months income
            return   _context.Racuni
                             .Where(x => x.Placen == 1)
                             .GroupBy(x => x.VrijemePlacanjaRacuna.Year)
                             .Select(g => new
                             {
                                 Godina = g.Select(x => x.VrijemePlacanjaRacuna.Year).FirstOrDefault(),
                                 TotalYearIncome = g.Sum(x => x.Vrijednost),
                                 Months = g.GroupBy(m => m.VrijemePlacanjaRacuna.Month)
                                              .Select(mo => new
                                              {
                                                  Mesec = mo.Select(m => m.VrijemePlacanjaRacuna.ToString("MMMMM", new CultureInfo("sr"))).FirstOrDefault(),
                                                  TotalMonthIncome = mo.Sum(m => m.Vrijednost)
                                              }).ToList()
                             })
                             .ToList();
        }

    }
}
