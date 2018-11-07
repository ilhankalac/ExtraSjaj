using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelContext _context;
        public IMusterijaRepository Musterije { get; private set; }
        public IRacunRepository Racuni { get; private set; }
        public UnitOfWork(ModelContext context)
        {
            _context = context;
            Musterije = new MusterijaRepository(_context);
            Racuni = new RacunRepository(_context);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
