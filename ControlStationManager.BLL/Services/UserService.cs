using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;
using ControlStationManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserForDisplayDto> GetUser(int userId)
        {
            var user = await _repository.GetUser(userId);
            return _mapper.Map<UserForDisplayDto>(user);
        }

        public async Task<UserForDisplayDto> UpdateUser(int userId, UserForUpdateDto user)
        {
            if (await _repository.UserExists(userId, user.Username))
            {
                throw new InvalidUsernameException(user.Username);
            }

            var mappedUser = _mapper.Map<User>(user);
            var updatedUser = await _repository.UpdateUser(userId, mappedUser);

            return _mapper.Map<UserForDisplayDto>(updatedUser);
        }
    }

    [Serializable]
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
        {
        }

        public InvalidUsernameException(string name)
            : base(String.Format("User with username: {0} already exists.", name))
        {
        }
    }
}
