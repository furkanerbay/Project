using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        IResult Add(IFormFile file, BookImage bookImage);
        IResult Delete(BookImage bookImage);
        IResult Update(IFormFile file, BookImage bookImage);
        IDataResult<List<BookImage>> GetAllNoAsync();
        IDataResult<List<BookImage>> GetByBookId(int bookId);
        IDataResult<BookImage> GetByImageId(int imageId); 
    }
}
