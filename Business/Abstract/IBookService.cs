using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookService
    {
        Task<IDataResult<List<Book>>> GetAll();
        Task<IDataResult<Book>> Get(int id);
        Task<Result> Add(Book entity);
        Task<Result> Delete(Book entity);
        Task<Result> Update(Book entity);
    }
}
