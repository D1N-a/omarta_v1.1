namespace omarta_v1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(nullable: false),
                        GalleryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Galleries", t => t.GalleryID, cascadeDelete: true)
                .Index(t => t.GalleryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "GalleryID", "dbo.Galleries");
            DropIndex("dbo.Photos", new[] { "GalleryID" });
            DropTable("dbo.Photos");
        }
    }
}
