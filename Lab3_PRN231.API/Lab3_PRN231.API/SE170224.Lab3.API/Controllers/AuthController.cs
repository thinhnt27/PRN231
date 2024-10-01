using Lab3_PRN231.API.RequestModel;
using Lab3_PRN231.API.ResponseModel;
using Lab3_PRN231.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SWD.F_LocalBrand.API.Common;

namespace Lab3_PRN231.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var result = await _service.Login(request.MapToModel());
            if (result == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            var response = new LoginResponseModel { Token = result };
            return Ok(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequestModel request)
        {
            var result = await _service.Register(request.MapToModel());
            var response = new RegisterResponseModel { Token = result };
            return Ok(response);
        }
    }
}
