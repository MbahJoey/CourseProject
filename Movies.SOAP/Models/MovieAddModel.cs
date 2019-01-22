using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.SOAP.Models
{
    public class MovieAddModel
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }

    }
}