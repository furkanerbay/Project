using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Result> Add(Book entity)
        {
            await _bookRepository.Add(entity);
            return new SuccessResult(Messages.BookAdded);
        }

        public async Task<Result> Delete(Book entity)
        {
            await _bookRepository.Delete(entity);
            return new SuccessResult(Messages.BookDeleted);
        }

        public async Task<IDataResult<Book>> Get(int id)
        {
            return new SuccessDataResult<Book>
                (await _bookRepository.Get(b => b.Id == id), Messages.BookGet);
        }

        public async Task<IDataResult<List<Book>>> GetAll()
        {
            return new SuccessDataResult<List<Book>>
                (await _bookRepository.GetAll(), Messages.BookGetAll);
        }

        public async Task<Result> Update(Book entity)
        {
            await _bookRepository.Update(entity);
            return new SuccessResult(Messages.BookUpdated);
        }
    }
}
