using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DB.Entities
{
    public interface IBaseEntity<T, K>
    {
        T Id { get; set; }
    }
};
