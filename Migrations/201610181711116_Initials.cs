namespace omarta_v1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Show = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        Author = c.String(),
                        Status = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SalesPrice = c.Double(nullable: false),
                        BuyPrice = c.Double(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        AvailableQuantity = c.Int(nullable: false),
                        LastChange = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        GalleryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Galleries", t => t.GalleryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.GalleryID);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Cover = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Show = c.Int(nullable: false),
                        Newsdate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        ImagePath = c.String(),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TakeDate = c.DateTime(nullable: false),
                        Text = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        GalleryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Galleries", t => t.GalleryID, cascadeDelete: true)
                .Index(t => t.GalleryID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Salesdate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Photos", "GalleryID", "dbo.Galleries");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Comments", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "GalleryID", "dbo.Galleries");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropIndex("dbo.Photos", new[] { "GalleryID" });
            DropIndex("dbo.Orders", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "GalleryID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "ProductID" });
            DropTable("dbo.Sales");
            DropTable("dbo.Photos");
            DropTable("dbo.Orders");
            DropTable("dbo.News");
            DropTable("dbo.Galleries");
            DropTable("dbo.Products");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
