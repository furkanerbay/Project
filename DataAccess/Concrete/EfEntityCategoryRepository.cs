using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEntityCategoryRepository : EfEntityRepository<Category, ProjectDbContext>, ICategoryRepository
    {
        public EfEntityCategoryRepository(ProjectDbContext tContext) : base(tContext)
        {
        }
    }
}
