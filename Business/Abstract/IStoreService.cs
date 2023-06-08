using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStoreService
    {
        Task<IDataResult<List<Store>>> GetAll();
        Task<IDataResult<Store>> Get(int id);
        Task<Result> Add(Store entity);
        Task<Result> Delete(Store entity);
        Task<Result> Update(Store entity);
    }
}
