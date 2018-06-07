using CourseProject.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataAcces.Repositories
{
    public class DirectorRepository : BaseRepository<Director>
    {
        public DirectorRepository(MoviesDbContext context)
        {
            this.Context = context;
        }

        public void Save(Director director)
        {
            if (director.Id == 0)
            {
                Create(director);
            }
            else
            {
                Update(director, item => item.Id == director.Id);
            }
        }
    }
}
