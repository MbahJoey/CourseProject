using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DB.Entities
{
    class Film : BaseEntity
    {
        [Required, StringLength(120)]
        public string Title { get; set; }

        [Required]
        public int DirId { get; set; }

        [Required,]
        public int GenreId { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }


    }
}
