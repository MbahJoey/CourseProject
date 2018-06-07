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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да съдържа между 3 и 50 символа!")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да съдържа между 3 и 50 символа!")]
        public string DirectorName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Жанра трябва да съдържа между 3 и 30 символа!")]
        public string GenreName { get; set; }
    }
}
