using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProvinceService
    {
        Task<IDataResult<List<Province>>> GetAll();
        Task<IDataResult<Province>> Get(int id);
        Task<Result> Add(Province entity);
        Task<Result> Delete(Province entity);
        Task<Result> Update(Province entity);
    }
}
