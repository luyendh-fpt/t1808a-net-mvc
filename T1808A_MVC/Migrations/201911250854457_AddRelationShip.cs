namespace T1808A_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationShip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CategoryId");
            AddForeignKey("dbo.Students", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Students", new[] { "CategoryId" });
            DropColumn("dbo.Students", "CategoryId");
        }
    }
}
