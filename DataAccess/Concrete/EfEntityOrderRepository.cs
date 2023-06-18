using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEntityOrderRepository : EfEntityRepository<Order, ProjectDbContext>, IOrderRepository
    {
        private readonly ProjectDbContext context;
        public EfEntityOrderRepository(ProjectDbContext tContext) : base(tContext)
        {
            context = tContext;
        }

        public async Task<List<OrderDetailsDto>> GetAllOrderDetailsDto()
        {
            var result = from order in context.Orders
                         join user in context.Users
                         on order.UserId equals user.Id
                         join province1 in context.Provinces
                         on order.UserProvinceId equals province1.Id
                         join store in context.Store
                         on order.StoreId equals store.Id
                         join province2 in context.Provinces
                         on order.StoreProvinceId equals province2.Id
                         select new OrderDetailsDto
                         {
                             Id = order.Id,
                             UserName = user.FirstName + " " + user.LastName,
                             UserProvinceName = province1.ProvinceName,
                             StoreName = store.StoreName,
                             StoreProvinceName = province2.ProvinceName
                         };

            return await result.ToListAsync();
        }

        
    }
}
