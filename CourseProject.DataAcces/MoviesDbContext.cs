 using System.Threading.Tasks;
 using CourseProject.DB.Entities;
 using System;
 using System.Data.Entity;
 using System.Linq;

namespace CourseProject.DataAcces
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        public MoviesDbContext()
        {   
            
        }
    }
}
