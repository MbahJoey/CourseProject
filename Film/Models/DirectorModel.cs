using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Film.Models
{
    public class DirectorModel
    {
        [Required]
        public string DirectorName { get; set; }
    }
}