using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
