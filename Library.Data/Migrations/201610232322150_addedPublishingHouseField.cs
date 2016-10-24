namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPublishingHouseField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublishingYear", c => c.Int());
            AddColumn("dbo.Books", "PublishingHouse", c => c.String());
            DropColumn("dbo.Books", "PublishingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PublishingDate", c => c.DateTime());
            DropColumn("dbo.Books", "PublishingHouse");
            DropColumn("dbo.Books", "PublishingYear");
        }
    }
}
