using System.Data.Entity;


namespace ExtraSjaj.Modeli
{
    public  class ModelContext :DbContext
    {
        public ModelContext() :
            base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TepisiBaza-2018;Integrated Security=True")
            { }

        public DbSet<Musterija> Musterije { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Tepih> Tepisi { get; set; }
        public DbSet<StatistikaMusterija> StatistikeMusterija { get; set; }
    }
}
