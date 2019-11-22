namespace T1808A_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherClasses");
        }
    }
}
