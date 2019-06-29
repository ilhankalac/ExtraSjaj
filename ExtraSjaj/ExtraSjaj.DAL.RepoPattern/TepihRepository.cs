using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class TepihRepository : Repository<Tepih>, ITepihRepository
    {
        protected readonly ExtraSjajContext _context;

        public TepihRepository(ExtraSjajContext context) : base(context)
        {
            _context = context;
        }

        public ExtraSjajContext context
        {
            get { return context as ExtraSjajContext; }
        }


        public async Task<IEnumerable<Tepih>> GetTepisiByRacunId(int RacunId)
        {
            return await _context.Tepisi.Where(x => x.RacunId == RacunId).ToListAsync();
        }
    }
}
