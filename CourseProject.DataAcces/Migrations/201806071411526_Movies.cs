namespace CourseProject.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DirectorName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Movies", "GenreName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Movies", "Director", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Movies", "GenreName");
            DropColumn("dbo.Movies", "DirectorName");
        }
    }
}
