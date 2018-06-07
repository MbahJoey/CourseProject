using CourseProject.DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Film.Models
{
    public class MoviesModel
    {
        #region Properties
            [Required(ErrorMessage = "Movie Title must contain from 3 to 50 symbols")]
            [StringLength(50, MinimumLength = 3)]
            public string Title { get; set; }

            [Required(ErrorMessage = "Directors name must contain from 3 to 50 symbols")]
            [StringLength(50, MinimumLength = 3)]
            public string DirectorName { get; set; }

            [Required(ErrorMessage = "Genre must contain from 3 to 30 symbols")]
            [StringLength(30, MinimumLength = 3)]
            public string GenreName { get; set; }
        #endregion

        #region Constructors
        public MoviesModel(Movie e)
        {
            Title = e.Title;
            GenreName = e.GenreName;
            DirectorName = e.DirectorName;
        }
        #endregion
    }
}