namespace Trpz2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTagToNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "TagId", "dbo.Tags");
            DropIndex("dbo.Products", new[] { "TagId" });
            AlterColumn("dbo.Products", "TagId", c => c.Long());
            CreateIndex("dbo.Products", "TagId");
            AddForeignKey("dbo.Products", "TagId", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "TagId", "dbo.Tags");
            DropIndex("dbo.Products", new[] { "TagId" });
            AlterColumn("dbo.Products", "TagId", c => c.Long(nullable: false));
            CreateIndex("dbo.Products", "TagId");
            AddForeignKey("dbo.Products", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
