using CourseProject.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataAcces.Repositories
{
        public class GenreRepository : BaseRepository<Genre>
        {
            public GenreRepository(MoviesDbContext context)
            {
                this.Context = context;
            }

            public void Save(Genre genre)
            {
                if (genre.Id == 0)
                {
                    Create(genre);
                }
                else
                {
                    Update(genre, item => item.Id == genre.Id);
                }
            }
        }
}

