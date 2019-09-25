namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goods", "SellerID", c => c.String());
            AlterColumn("dbo.Orders", "BuyerID", c => c.String());
            AlterColumn("dbo.Orders", "SellerID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "SellerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "BuyerID", c => c.Int(nullable: false));
            DropColumn("dbo.Goods", "SellerID");
        }
    }
}
