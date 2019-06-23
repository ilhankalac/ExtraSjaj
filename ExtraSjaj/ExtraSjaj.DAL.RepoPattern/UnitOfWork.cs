using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly ExtraSjajContext _context;

        public IMusterijaRepository Musterije { get; }


        public UnitOfWork(ExtraSjajContext context)
        {
            _context = context;
            Musterije = new MusterijaRepository(_context);
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
