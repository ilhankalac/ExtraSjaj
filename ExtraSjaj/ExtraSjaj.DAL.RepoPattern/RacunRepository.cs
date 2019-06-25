using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraSjaj.DAL.RepoPattern
{
    public class RacunRepository : Repository<Racun>, IRacunRepository
    {
        protected readonly ExtraSjajContext _context;

        public RacunRepository(ExtraSjajContext context) : base(context)
        {
            _context = context;
        }

        public ExtraSjajContext context
        {
            get { return context as ExtraSjajContext; }
        }
    }
}
