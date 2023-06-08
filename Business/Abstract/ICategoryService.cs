using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAll();
        Task<IDataResult<Category>> Get(int id);
        Task<Result> Add(Category entity);
        Task<Result> Delete(Category entity);
        Task<Result> Update(Category entity);
    }
}
