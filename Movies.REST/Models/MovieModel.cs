using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseProject.DB.Entities;

namespace Movies.REST.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }

        public MovieModel() { }

        public MovieModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.DirectorName = movie.DirectorName;
            this.GenreName = movie.GenreName;
        }

        public void CopyToEntity(Movie dbmovie)
        {
            dbmovie.Title = this.Title;
            dbmovie.DirectorName = this.DirectorName;
            dbmovie.GenreName = this.GenreName;
        }
    }

}