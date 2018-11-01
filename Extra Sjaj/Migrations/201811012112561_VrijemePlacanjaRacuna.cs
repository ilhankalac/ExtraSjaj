namespace ExtraSjaj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VrijemePlacanjaRacuna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Racuni", "VrijemePlacanjaRacuna", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Racuni", "VrijemePlacanjaRacuna");
        }
    }
}
