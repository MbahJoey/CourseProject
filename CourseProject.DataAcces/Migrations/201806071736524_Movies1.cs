namespace CourseProject.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "DirectorName", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "GenreName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "GenreName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Movies", "DirectorName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
