using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEntityColorRepository : EfEntityRepository<Color, ProjectDbContext>, IColorRepository
    {
        public EfEntityColorRepository(ProjectDbContext tContext) : base(tContext)
        {
            
        }
    }
}
