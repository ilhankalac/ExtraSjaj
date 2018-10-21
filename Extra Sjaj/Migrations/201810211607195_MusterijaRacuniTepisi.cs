namespace ExtraSjaj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusterijaRacuniTepisi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musterije",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImePrezime = c.String(),
                        BrojTelefona = c.String(),
                        Adresa = c.String(),
                        VrijemeKreiranjaMusterije = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Racuni",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vrijednost = c.Double(nullable: false),
                        Placen = c.Boolean(nullable: false),
                        VrijemeKreiranjaRacuna = c.DateTime(nullable: false),
                        BrojTepiha = c.Int(nullable: false),
                        MusterijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Musterije", t => t.MusterijaId, cascadeDelete: true)
                .Index(t => t.MusterijaId);
            
            CreateTable(
                "dbo.Tepisi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duzina = c.Single(nullable: false),
                        Sirina = c.Single(nullable: false),
                        Kvadratura = c.Single(nullable: false),
                        RacunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Racuni", t => t.RacunId, cascadeDelete: true)
                .Index(t => t.RacunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tepisi", "RacunId", "dbo.Racuni");
            DropForeignKey("dbo.Racuni", "MusterijaId", "dbo.Musterije");
            DropIndex("dbo.Tepisi", new[] { "RacunId" });
            DropIndex("dbo.Racuni", new[] { "MusterijaId" });
            DropTable("dbo.Tepisi");
            DropTable("dbo.Racuni");
            DropTable("dbo.Musterije");
        }
    }
}
