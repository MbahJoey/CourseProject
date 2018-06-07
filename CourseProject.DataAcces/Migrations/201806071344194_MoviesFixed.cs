namespace CourseProject.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesFixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Movies", "PublishDate");
            DropColumn("dbo.Movies", "CreatedTime");
            DropTable("dbo.DirectorNames");
            DropTable("dbo.GenreNames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GenreNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(nullable: false, maxLength: 30),
                        GenreId = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DirectorNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Director = c.String(nullable: false, maxLength: 50),
                        DirId = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "PublishDate", c => c.DateTime(nullable: false));
            DropTable("dbo.Genres");
            DropTable("dbo.Directors");
        }
    }
}
