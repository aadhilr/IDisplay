namespace IDisplay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12334 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "PromotionalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "PromotionalPrice");
        }
    }
}
