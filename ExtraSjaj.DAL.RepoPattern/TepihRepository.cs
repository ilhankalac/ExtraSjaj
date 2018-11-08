using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class TepihRepository : Repository<Tepih>, ITepihRepository
    {
        public TepihRepository(ModelContext context) : base(context)
        { }
        public ModelContext context
        {
            get { return context as ModelContext; }
        }
    }
}
