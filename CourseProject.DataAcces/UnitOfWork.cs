using CourseProject.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataAcces
{
    public class UnitOfWork
    {
        private readonly MoviesDbContext context;

        private MovieRepository movieRepository;
        private GenreRepository genreRepository;
        private DirectorRepository directorRepository;

        public UnitOfWork(MoviesDbContext connection)
        {
            context = connection;
        }

        public MovieRepository MovieRepository
        {
            get
            {
                if (movieRepository == null)
                {
                    movieRepository = new MovieRepository(context);
                }

                return movieRepository;
            }
        }

        public GenreRepository GenreRepository
        {
            get
            {
                if (genreRepository == null)
                {
                    genreRepository = new GenreRepository(context);
                }

                return genreRepository;
            }
        }

        public DirectorRepository DirectorRepository
        {
            get
            {
                if (directorRepository == null)
                {
                    directorRepository = new DirectorRepository(context);
                }

                return directorRepository;
            }
        }
    }
}
