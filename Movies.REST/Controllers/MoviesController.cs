using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CourseProject.DataAcces.Repositories;
using Movies.REST.Models;
using CourseProject.DataAcces;
using CourseProject.DB.Entities;

namespace Movies.REST.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly MoviesDbContext db = new MoviesDbContext();
        private readonly UnitOfWork uow;

        /// <summary>
        /// calls an instance of unit of work
        /// </summary>
        public MoviesController() {
            uow = new UnitOfWork(new MoviesDbContext());
        }

        /// <summary>
        /// Get Method
        /// </summary>
        /// <returns>retuns all Movies</returns>
        [HttpGet]
        [Route]
        public List<MovieModel> Get()
        {
            var allMovies = uow.MovieRepository.GetAll()
                .Select(c => new MovieModel(c))
                .ToList();
            return allMovies;
        }


        /// <summary>
        /// Get by Id Method
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns>returns the selected movie if it exists</returns>
        [HttpGet]
        [Route("{MovieId:int}")]
        public IHttpActionResult GetById(int MovieId)
        {
            if (MovieId == null)
                return BadRequest("the parameter movieId is empty");

            Movie movie = uow.MovieRepository.GetById(MovieId);
            if (movie == null)
                return BadRequest($"Could not find movie with ID: {MovieId}");

            MovieModel apiMovie = new MovieModel(movie);
            return Ok(apiMovie);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut]
        [Route]
        public IHttpActionResult Put(MovieModel movie)
        {
            try
            {
                Movie dbmovie = uow.MovieRepository.GetById(movie.Id);
                if (dbmovie == null)
                    return NotFound();

                movie.CopyToEntity(dbmovie);
                uow.MovieRepository.PromoteOrDemote(dbmovie);

                uow.MovieRepository.Save(dbmovie);
                return StatusCode(HttpStatusCode.NoContent); 

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        [Route]
        public IHttpActionResult Post(MovieModel movie) {
            try
            {
                Movie dbmovie = new Movie();

                movie.CopyToEntity(dbmovie);
                uow.MovieRepository.Create(dbmovie);

                MovieModel newmovie = new MovieModel(dbmovie);
                return Ok(newmovie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        /// <response></response>
        [HttpDelete]
        [Route("{MovieID:int}")]
        public IHttpActionResult Delete(int MovieId)
        {
            try
            {
                Movie dbmovie = uow.MovieRepository.GetById(MovieId);
                if (dbmovie == null)
                    return NotFound();
                uow.MovieRepository.DeleteByID(MovieId);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
