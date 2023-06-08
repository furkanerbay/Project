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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result> Add(Category entity)
        {
            await _categoryRepository.Add(entity);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public async Task<Result> Delete(Category entity)
        {
            await _categoryRepository.Delete(entity);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public async Task<IDataResult<Category>> Get(int id)
        {
            return new SuccessDataResult<Category>
                (await _categoryRepository.Get(c => c.Id == id), Messages.CategoryGet);
        }

        public async Task<IDataResult<List<Category>>> GetAll()
        {
            return new SuccessDataResult<List<Category>>
                (await _categoryRepository.GetAll(), Messages.CategoryGetAll);
        }

        public async Task<Result> Update(Category entity)
        {
            await _categoryRepository.Update(entity);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
