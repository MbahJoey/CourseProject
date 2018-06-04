using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DB.Entities
{
    class Director : BaseEntity
    {
        [Required, StringLength(50)]
        public string DirName { get; set; }

        [Required]
        public int DirId { get; set; }

    }
}
