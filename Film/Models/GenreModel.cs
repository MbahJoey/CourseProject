using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Film.Models
{
    public class GenreModel
    {
        [Required]
        public string GenreName { get; set; }
    }
}