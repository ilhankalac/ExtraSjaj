namespace ExtraSjaj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpajanjeStatistikeSaMusterijom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StatistikeMusterija", "UkupnoNovca", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.StatistikeMusterija", "BrojOpranihTepiha", c => c.Int(nullable: false));
            AddColumn("dbo.StatistikeMusterija", "MusterijaId", c => c.Int(nullable: false));
            CreateIndex("dbo.StatistikeMusterija", "MusterijaId");
            AddForeignKey("dbo.StatistikeMusterija", "MusterijaId", "dbo.Musterije", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatistikeMusterija", "MusterijaId", "dbo.Musterije");
            DropIndex("dbo.StatistikeMusterija", new[] { "MusterijaId" });
            DropColumn("dbo.StatistikeMusterija", "MusterijaId");
            DropColumn("dbo.StatistikeMusterija", "BrojOpranihTepiha");
            DropColumn("dbo.StatistikeMusterija", "UkupnoNovca");
        }
    }
}
