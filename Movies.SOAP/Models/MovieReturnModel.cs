using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseProject.DB.Entities;



namespace Movies.SOAP.Models
{
    public class MovieReturnModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }


        public string ErrorMessage { get; set; }

        public MovieReturnModel() {}

        public MovieReturnModel(CourseProject.DB.Entities.Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.DirectorName = movie.DirectorName;
            this.GenreName = movie.GenreName;
        }
    }
}