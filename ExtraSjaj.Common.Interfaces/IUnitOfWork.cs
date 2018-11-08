using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMusterijaRepository Musterije { get; }
        IRacunRepository Racuni { get; }
        ITepihRepository Tepisi { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
