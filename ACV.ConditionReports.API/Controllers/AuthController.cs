using ACV.ConditionReports.API.Models.Request;
using ACV.ConditionReports.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ACV.ConditionReports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] UserLogin user)
        {
            string _token = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _token = await _authService.Login(user.Username, user.Password);

                if (string.IsNullOrEmpty(_token))
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

            return Ok(new { Token = _token });
        }
    }
}
