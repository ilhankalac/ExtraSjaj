using ExtraSjaj.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IMusterijaRepository : IRepository<Musterija>
    {
        Task<IEnumerable<Musterija>> GetMusterijeReversed();
    }
}
