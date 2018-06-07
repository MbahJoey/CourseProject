using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DB.Entities
{
    public class Genre : BaseEntity
    {
        [Required, StringLength(30)]
        public string GenreName { get; set; }
    }
}
