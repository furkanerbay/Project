using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.GetNoAsync(u => u.EMail == email);
        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            return new SuccessDataResult<List<User>>(await _userRepository.GetAll(),"Kisiler getirildi.");
        }
    }
}
