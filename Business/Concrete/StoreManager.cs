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
    public class StoreManager : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreManager(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<Result> Add(Store entity)
        {
            await _storeRepository.Add(entity);
            return new SuccessResult(Messages.StoreAdded);
        }

        public async Task<Result> Delete(Store entity)
        {
            await _storeRepository.Delete(entity);
            return new SuccessResult(Messages.StoreDeleted);
        }

        public async Task<IDataResult<Store>> Get(int id)
        {
            return new SuccessDataResult<Store>
                (await _storeRepository.Get(c => c.Id == id), Messages.ColorGet);
        }

        public async Task<IDataResult<List<Store>>> GetAll()
        {
            return new SuccessDataResult<List<Store>>
                (await _storeRepository.GetAll(), Messages.ColorGetAll);
        }

        public async Task<Result> Update(Store entity)
        {
            await _storeRepository.Update(entity);
            return new SuccessResult(Messages.StoreUpdated);
        }
    }
}
