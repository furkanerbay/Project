using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<List<Order>>> GetAll();
        Task<IDataResult<Order>> GetById(int id);
        Task<Result> Add(Order entity);
        Task<Result> Delete(Order entity);
        Task<Result> Update(Order entity);
        Task<IDataResult<List<OrderDetailsDto>>> GetAllDetailsDto();
        Result UpdateNotAsync(Order order);
    }
}
