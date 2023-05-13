using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models;
using AuthenticationAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace AuthenticationAPI.Services
{
    public class UserService
    {
        private readonly IRepo _repo;
        private readonly IGenerateToken _generateToken;

        public UserService(IRepo repo,IGenerateToken generateToken)
        {
            _repo = repo;
            _generateToken = generateToken;
        }
        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            USer myDBUser = new USer()
            {
                Username = userDTO.Username
            };
            var result = await _repo.Get(myDBUser);
            if(result !=null)
            {
                HMACSHA512 hmac = new HMACSHA512(result.HashKey);
                var encptPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)); 
                for(int i = 0; i < encptPass.Length; i++)
                {
                    if (encptPass[i] != result.Password[i])
                    {
                        return null;
                    }
                }
            }
            userDTO.Password = string.Empty;
            userDTO.Role = result.Role;
            userDTO.Token = _generateToken.GenerateToken(userDTO);
            return userDTO;
        }
        public async Task<UserDTO> Register(UserDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            USer myDBUser = new USer()
            {
                Username = userDTO.Username,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                HashKey = hmac.Key,
                Role = userDTO.Role
            };
            var result = await _repo.Add(myDBUser);
            userDTO.Password = string.Empty;
            userDTO.Token = _generateToken.GenerateToken(userDTO);
            return userDTO;
        }
    }
}
