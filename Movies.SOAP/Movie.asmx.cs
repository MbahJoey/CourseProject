using Movies.SOAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CourseProject.DataAcces.Repositories;
using CourseProject.DataAcces;
using CourseProject.DB.Entities;

namespace Movies.SOAP
{
    /// <summary>
    /// Summary description for Movie
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Movie : System.Web.Services.WebService
    {
        private readonly MoviesDbContext db = new MoviesDbContext();
        private readonly UnitOfWork uow;

        /// <summary>
        /// calls an instance
        /// </summary>
        public Movie()
        {
            uow = new UnitOfWork(new MoviesDbContext());
        }

        /// <summary>
        /// Get all method
        /// </summary>
        /// <returns>returns a list of all existing Movies</returns>
        [WebMethod]
        public List<MovieReturnModel> GetAll()
        {
            List<MovieReturnModel> result = uow.MovieRepository.GetAll()
                .Select(b => new MovieReturnModel(b))
                .ToList(); ;
            return result;
        }

        /// <summary>
        /// Get by ID method
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns>returns just the selected movie="MovieId" if it exists</returns>
        [WebMethod]
        public MovieReturnModel GetByID(int MovieId)
        {
            CourseProject.DB.Entities.Movie movie = uow.MovieRepository.GetById(MovieId);
            if (movie == null)
                throw new Exception($"Could not find movie with ID: {MovieId}");

            MovieReturnModel result = new MovieReturnModel();
            return result;
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns>Deletes the selected movie if it exists</returns>
        [WebMethod]
        public string DeleteMovie(int MovieId)
        {
            CourseProject.DB.Entities.Movie movie = uow.MovieRepository.GetById(MovieId);
            if (movie == null)
                throw new Exception($"Could not find movie with ID: {MovieId}");

            uow.MovieRepository.DeleteByID(MovieId);
            return "Book is deleted successfully";
        }

        /// <summary>
        /// Create method
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Adds new movie="nmovie"</returns>
        [WebMethod]
        public string AddMovie(MovieAddModel movie)
        {
            CourseProject.DB.Entities.Movie nmovie = new CourseProject.DB.Entities.Movie();
            nmovie.DirectorName = movie.DirectorName;
            nmovie.GenreName = movie.GenreName;
            nmovie.Title = movie.Title;
            uow.MovieRepository.Create(nmovie);

            return "Book is added successfully";
        }
    }
}
