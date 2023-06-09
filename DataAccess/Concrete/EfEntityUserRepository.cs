using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEntityUserRepository : EfEntityRepository<User, ProjectDbContext>, IUserRepository
    {
        private readonly ProjectDbContext context;
        public EfEntityUserRepository(ProjectDbContext tcontext) : base(tcontext)
        {
            context = tcontext;
        }
        
        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaim
                         on operationClaim.Id equals userOperationClaim.Id
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name
                         };

            return result.ToList();
        }
    }
}
