using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class MusterijaRepository : Repository<Musterija>, IMusterijaRepository
    {
        protected readonly ExtraSjajContext _context;

        public MusterijaRepository(ExtraSjajContext context) : base(context)
        {
            _context = context;
        }

        public ExtraSjajContext context
        {
            get { return context as ExtraSjajContext; }
        }

        public async Task<IEnumerable<Musterija>> GetMusterijeReversed()
        {
            return await _context.Musterije.OrderByDescending(x => x.Id).ToListAsync();
        }

    }
}
