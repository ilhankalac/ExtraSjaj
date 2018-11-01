namespace ExtraSjaj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RazdvajanjeImenaIPrezimenaMusterije : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musterije", "Ime", c => c.String());
            AddColumn("dbo.Musterije", "Prezime", c => c.String());
            DropColumn("dbo.Musterije", "ImePrezime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musterije", "ImePrezime", c => c.String());
            DropColumn("dbo.Musterije", "Prezime");
            DropColumn("dbo.Musterije", "Ime");
        }
    }
}
