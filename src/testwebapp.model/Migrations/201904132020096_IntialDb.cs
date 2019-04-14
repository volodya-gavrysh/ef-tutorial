namespace testwebapp.model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ISBN = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Title = c.String(nullable: false, unicode: false),
                        Author = c.String(unicode: false),
                        Language = c.String(unicode: false),
                        Pages = c.Int(nullable: false),
                        Publisher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ISBN)
                .ForeignKey("dbo.Publishers", t => t.Publisher_ID)
                .Index(t => t.Publisher_ID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Publisher_ID", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "Publisher_ID" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
        }
    }
}
