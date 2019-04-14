namespace testwebapp.model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublisherDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "Description", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "Description");
        }
    }
}
