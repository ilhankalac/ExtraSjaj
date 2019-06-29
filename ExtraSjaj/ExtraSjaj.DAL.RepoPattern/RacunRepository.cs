using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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

            _context.SaveChangesAsync();
        }

        float ukupnaKvadratura(int RacunId)
        {
            return _context.Tepisi.Where(x => x.RacunId == RacunId).Sum(x => x.Kvadratura);
        }

      
    }
}
