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
    public class ColorManager : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorManager(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<Result> Add(Color entity)
        {
            await _colorRepository.Add(entity);
            return new SuccessResult(Messages.ColorAdded);
        }

        public async Task<Result> Delete(Color entity)
        {
            await _colorRepository.Delete(entity);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public async Task<IDataResult<Color>> Get(int id)
        {
            return new SuccessDataResult<Color>
                (await _colorRepository.Get(c => c.Id == id),Messages.ColorGet);
        }

        public async Task<IDataResult<List<Color>>> GetAll()
        {
            return new SuccessDataResult<List<Color>>
                (await _colorRepository.GetAll(),Messages.ColorGetAll);
        }

        public async Task<Result> Update(Color entity)
        {
            await _colorRepository.Update(entity);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
