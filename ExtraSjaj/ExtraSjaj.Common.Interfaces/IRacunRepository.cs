using ExtraSjaj.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IRacunRepository : IRepository<Racun>
    {
        Task<IEnumerable<Racun>> getRacuniByMusterijaId(int MusterijaId);
    }
}
