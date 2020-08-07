using AutoMapper;
using ControlStationManager.DAL.Entities;
using ControlStationManager.DAL.Models;
using ControlStationManager.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControlStationManager.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IMapper mapper,
               IConfiguration configuration)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserForDisplayDto> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _authRepository.UserExists(userForRegisterDto.Username))
            {
                throw new InvalidUserException(userForRegisterDto.Username);
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);

            return _mapper.Map<UserForDisplayDto>(createdUser);
        }

        public async Task<string> Login(UserForLoginDto userForRegisterDto)
        {
            var userFromRepo = await _authRepository.Login(userForRegisterDto.Username.ToLower(),
                    userForRegisterDto.Password);
            if (userFromRepo == null)
                return null;

            var secretKey = _configuration.GetSection("AppSettings:Token").Value;
            var tokenString = GenerateToken(userFromRepo, secretKey);
            return tokenString;
        }

        #region Helpers

        private static string GenerateToken(User userFromRepo, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        #endregion
    }

    [Serializable]
    public class InvalidUserException : Exception
    {
        public InvalidUserException()
        {

        }

        public InvalidUserException(string username)
        : base(String.Format("User with username: {0} already exists.", username))
        {

        }
    }
}
