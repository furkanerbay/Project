using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<List<Color>>> GetAll();
        Task<IDataResult<Color>> Get(int id);
        Task<Result> Add(Color entity);
        Task<Result> Delete(Color entity);
        Task<Result> Update(Color entity);
    }
}
