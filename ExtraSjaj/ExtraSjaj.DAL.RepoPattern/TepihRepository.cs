using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;

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
    }
}
