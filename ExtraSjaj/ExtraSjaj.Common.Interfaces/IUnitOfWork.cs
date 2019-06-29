using System;
using System.Threading.Tasks;
namespace ExtraSjaj.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMusterijaRepository Musterije { get; }
        IRacunRepository Racuni { get; }
        ITepihRepository Tepisi { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
