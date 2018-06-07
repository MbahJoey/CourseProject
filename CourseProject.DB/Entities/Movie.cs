using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DB.Entities
{
     public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [Required]
        public string GenreName { get; set; }
    }
}
