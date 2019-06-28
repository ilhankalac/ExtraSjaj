using ExtraSjaj.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtraSjaj.Common.Interfaces
{
    public interface ITepihRepository : IRepository<Tepih>
    {
        Task<IEnumerable<Tepih>> GetTepisiByRacunId(int RacunId);
    }
}
