using System.Data.Entity;


namespace ExtraSjaj.Modeli
{
    public  class ModelContext :DbContext
    {
        public ModelContext() :
            base(@"Data Source=91.148.81.243, 1433;Initial Catalog=TepisiBaza-2018;Integrated Security=False;User ID=admin;Password=admin123;Connect Timeout=30;")
            { }

        public DbSet<Musterija> Musterije { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Tepih> Tepisi { get; set; }
        public DbSet<StatistikaMusterija> StatistikeMusterija { get; set; }
    }
}
