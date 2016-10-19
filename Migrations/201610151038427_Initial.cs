namespace omarta_v1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Gallery_ID", "dbo.Galleries");
            DropIndex("dbo.Products", new[] { "Gallery_ID" });
            RenameColumn(table: "dbo.Products", name: "Gallery_ID", newName: "GalleryID");
            AlterColumn("dbo.Products", "GalleryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "GalleryID");
            AddForeignKey("dbo.Products", "GalleryID", "dbo.Galleries", "ID", cascadeDelete: true);
            DropColumn("dbo.Products", "GelleryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "GelleryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "GalleryID", "dbo.Galleries");
            DropIndex("dbo.Products", new[] { "GalleryID" });
            AlterColumn("dbo.Products", "GalleryID", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "GalleryID", newName: "Gallery_ID");
            CreateIndex("dbo.Products", "Gallery_ID");
            AddForeignKey("dbo.Products", "Gallery_ID", "dbo.Galleries", "ID");
        }
    }
}
