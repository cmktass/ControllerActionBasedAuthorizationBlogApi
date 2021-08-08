using AutoMapper;
using cmkts.blog.business.Interface;
using cmkts.blog.dataaccess.Interface;
using cmkts.blog.entities.Entities;
using cmkts.blog.viewmodel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cmkts.blog.business.Concrete
{
    public class UserService:GenericService<User>,IUserService
    {
        private IGenericRepository<User> _genericRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IGenericRepository<User> genericRepository, IUserRepository userRepository, IMapper mapper) :base(genericRepository)
        {
            _genericRepository = genericRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<bool> Register(UserVM userVM)
        {
            CreatePasswordHash(userVM.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = _mapper.Map<User>(userVM);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return _userRepository.Register(user);
        }

        public async Task<bool> UserExist(string username)
        {
            if (await _userRepository.UserExist(username) != null)
            {
                return false;
            }
            return false;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
    }
}
