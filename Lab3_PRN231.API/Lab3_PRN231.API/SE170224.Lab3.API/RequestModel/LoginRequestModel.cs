using Lab3_PRN231.Service.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace Lab3_PRN231.API.RequestModel
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginModel MapToModel()
        {
            return new LoginModel { Username = Username, Password = Password };
        }
    }
}
