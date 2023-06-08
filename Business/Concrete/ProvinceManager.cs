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
    public class ProvinceManager : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        public ProvinceManager(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public async Task<Result> Add(Province entity)
        {
            await _provinceRepository.Add(entity);
            return new SuccessResult(Messages.ProvinceAdded);
        }

        public async Task<Result> Delete(Province entity)
        {
            await _provinceRepository.Delete(entity);
            return new SuccessResult(Messages.ProvinceDeleted);
        }

        public async Task<IDataResult<Province>> Get(int id)
        {
            return new SuccessDataResult<Province>
                (await _provinceRepository.Get(p => p.Id == id), Messages.ProvinceGet);
        }

        public async Task<IDataResult<List<Province>>> GetAll()
        {
            return new SuccessDataResult<List<Province>>
                (await _provinceRepository.GetAll(), Messages.ProvinceGetAll);
        }

        public async Task<Result> Update(Province entity)
        {
            await _provinceRepository.Update(entity);
            return new SuccessResult(Messages.ProvinceUpdated);
        }
    }
}
