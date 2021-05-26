namespace StoreDSWI.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageURLinProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageURL");
        }
    }
}
