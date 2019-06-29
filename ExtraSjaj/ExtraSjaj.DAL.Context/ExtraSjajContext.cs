using ExtraSjaj.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraSjaj.DAL.Context
{
    public class ExtraSjajContext : DbContext
    {
        public ExtraSjajContext(DbContextOptions<ExtraSjajContext> options) : base(options)
        {

        }

        public DbSet<Musterija> Musterije { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Tepih> Tepisi { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
