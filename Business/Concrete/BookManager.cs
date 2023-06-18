using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        //[ValidationAspect(typeof(BookValidator))]
        //[SecuredOperation("admin")]
        public async Task<Result> Add(Book entity)
        {
            //IResult result = BusinessRules.Run(CheckIfBookNameExists(entity.BookName));
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

        public async Task<IDataResult<List<BookDetailsDto>>> GetAllDetailsDto()
        {
            return new SuccessDataResult<List<BookDetailsDto>>
                (await _bookRepository.GetAllDetailsDto(), "Kitap detaylari getirildi.");
        }

        public async Task<Result> Update(Book entity)
        {
            await _bookRepository.Update(entity);
            return new SuccessResult(Messages.BookUpdated);
        }

        private IResult CheckIfBookNameExists(string bookName)
        {
            var result = _bookRepository.GetAll(b => b.BookName == bookName).Result.Any();

            if(result)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
