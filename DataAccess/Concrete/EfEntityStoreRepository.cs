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
    public class EfEntityStoreRepository : EfEntityRepository<Store, ProjectDbContext>, IStoreRepository
    {
        public EfEntityStoreRepository(ProjectDbContext tContext) : base(tContext)
        {
        }
    }
}
