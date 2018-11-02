namespace ExtraSjaj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatistikaMusterija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatistikeMusterija",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StatistikeMusterija");
        }
    }
}
