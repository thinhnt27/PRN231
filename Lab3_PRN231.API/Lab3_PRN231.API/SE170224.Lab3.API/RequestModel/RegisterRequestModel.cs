using Lab3_PRN231.Service.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace Lab3_PRN231.API.RequestModel
{
    public class RegisterRequestModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }

        public RegisterModel MapToModel()
        {
            return new RegisterModel { Username = Username, Password = Password };
        }
    }
}
