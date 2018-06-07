using CourseProject.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataAcces.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(MoviesDbContext context)
        {
            this.Context = context;
        }

        public void Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                Create(movie);
            }
            else
            {
                Update(movie, item => item.Id == movie.Id);
            }
        }
    }
}
