namespace omarta_v1._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "ImagePath", c => c.String(nullable: false));
        }
    }
}
