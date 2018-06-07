using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataAcces
{
    class MyConfig : DbConfiguration
    {
        public MyConfig()
        {
            SetDefaultConnectionFactory(
               new LocalDbConnectionFactory("MSSQLLocalDB")
               );
        }
    }
}
