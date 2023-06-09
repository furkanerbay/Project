using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        private IBookImageRepository _bookImageRepository;
        private IFileHelper _fileHelper;

        public BookImageManager(IBookImageRepository bookImageRepository, IFileHelper fileHelper)
        {
            _bookImageRepository = bookImageRepository;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, BookImage bookImage)
        {
            bookImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            bookImage.Date = DateTime.Now;
            _bookImageRepository.Add(bookImage);
            return new SuccessResult("Kitaba resim eklendi.");
        }

        public IResult Delete(BookImage bookImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + bookImage.ImagePath);
            _bookImageRepository.Delete(bookImage);
            return new SuccessResult("Kitabın resmi silindi.");
        }

        public IDataResult<List<BookImage>> GetAllNoAsync()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageRepository.GetAllNoAsync(),
                "Butun kitaplar getirildi.");
        }

        public IDataResult<List<BookImage>> GetByBookId(int bookId)
        {
            var result = _bookImageRepository.GetAllNoAsync(b => b.BookId == bookId);

            if(result.Count > 0)
            {
                return new SuccessDataResult<List<BookImage>>(result);
            }

            List<BookImage> images = new List<BookImage>();
            images.Add(new BookImage()
            {
                BookId = 0,
                Id = 0,
                Date = DateTime.Now,
                ImagePath = @"\Upload\Images\Default.jpg"
            });

            return new SuccessDataResult<List<BookImage>>(images);

        }

        public IDataResult<BookImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<BookImage>(_bookImageRepository.GetNoAsync(b => b.Id == imageId));
        }

        public IResult Update(IFormFile file, BookImage bookImage)
        {
            bookImage.ImagePath = _fileHelper.Update(file,PathConstants.ImagePath + bookImage.ImagePath , PathConstants.ImagePath);
            _bookImageRepository.Update(bookImage);
            return new SuccessResult("Kitap resmi guncellendi.");
        }
    }
}
