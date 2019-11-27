namespace T1808A_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductCategoryRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ProductCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductCategoryId");
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropColumn("dbo.Products", "ProductCategoryId");
            DropColumn("dbo.Products", "Price");
            DropTable("dbo.ProductCategories");
        }
    }
}
