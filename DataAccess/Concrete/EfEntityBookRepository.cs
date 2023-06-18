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
    public class EfEntityBookRepository : EfEntityRepository<Book, ProjectDbContext>, IBookRepository
    {
        private readonly ProjectDbContext context;   
        public EfEntityBookRepository(ProjectDbContext tContext) : base(tContext)
        {
            context = tContext;
        }

        public async Task<List<BookDetailsDto>> GetAllDetailsDto()
        {
            var result = from book in context.Books
                         join category in context.Categories
                         on book.CategoryId equals category.Id
                         join color in context.Colors
                         on book.ColorId equals color.Id
                         select new BookDetailsDto
                         {
                             Id = book.Id,
                             BookName = book.BookName,
                             CategoryName = category.CategoryName,
                             ColorName = color.ColorName,
                             NumberOfPages = book.NumberOfPages,
                             Description = book.Description
                         };

                         return await result.ToListAsync();

        }
    }
}
