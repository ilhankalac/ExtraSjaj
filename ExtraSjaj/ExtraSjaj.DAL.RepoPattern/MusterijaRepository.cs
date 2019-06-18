using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class MusterijaRepository : Repository<Musterija>, IMusterijaRepository
    {
        protected readonly ExtraSjajContext _context;

        public MusterijaRepository(ExtraSjajContext context) : base(context)
        {
            _context = context;
        }

        public ExtraSjajContext context
        {
            get { return context as ExtraSjajContext; }
        }
    }
}
