using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DB.Entities
{
    public class Director : BaseEntity
    {
        [Required]
        public string DirectorName { get; set; }


    }
}
