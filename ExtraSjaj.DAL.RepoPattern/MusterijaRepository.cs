using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class MusterijaRepository :Repository<Musterija>, IMusterijaRepository
    {
        public MusterijaRepository(ModelContext context): base(context)
        { }
        public ModelContext context
        {
            get { return context as ModelContext; }
        }

    }
}
