namespace Trpz2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_PriceField_To_SpecialOffer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialOffers", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecialOffers", "Price");
        }
    }
}
