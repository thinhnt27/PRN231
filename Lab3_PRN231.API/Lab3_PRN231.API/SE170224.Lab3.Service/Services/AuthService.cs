using Lab3_PRN231.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Lab3_PRN231.Service.BusinessModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SE170224.PRN231.Repository.UnitOfWork;
using System.Security.Cryptography;

namespace Lab3_PRN231.Service.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<string?> Login(LoginModel request)
        {
            var user = (await _unitOfWork.AccountsRepository.GetAsync(a => a.Username == request.Username && a.Password == Hash(request.Password)))
                        .FirstOrDefault();

            if (user == null)
                return null;

            var claims = new Claim[]
            {
                new Claim("username", user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = GenerateJSONWebToken(claims);

            return token;
        }

        public async Task<string> Register(RegisterModel request)
        {
            try
            {
                var account = new Account
                {
                    Username = request.Username,
                    Password = Hash(request.Password),
                    Role = RoleEnum.User
                };

                await _unitOfWork.AccountsRepository.InsertAsync(account);
                await _unitOfWork.SaveAsync();
                var claims = new Claim[]
            {
                new Claim("username", account.Username),
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Role, account.Role.ToString())
            };

                var token = GenerateJSONWebToken(claims);

                return token;
            }
            catch(Exception e)
            {
                return e.Message;
            }
            
        }

        public string GenerateJSONWebToken(Claim[] claims, int expireInMins = 5)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expireInMins),
                SigningCredentials = credentials,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static string Hash(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha256.ComputeHash(bytes);
            var stringBuilder = new StringBuilder();

            foreach (var b in hash)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
