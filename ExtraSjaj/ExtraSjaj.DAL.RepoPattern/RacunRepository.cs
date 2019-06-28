using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

            return await _context.Racuni.Where(x => x.MusterijaId == MusterijaId).ToListAsync();
        }

    }
}
