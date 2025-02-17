using ACV.ConditionReports.API.Helpers;
using ACV.ConditionReports.API.Models.Request;
using ACV.ConditionReports.API.Services;
using ACV.ConditionReports.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost("login")]
        public IActionResult Post([FromBody] UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string _token = _authService.Login(user.Username, user.Password);

            if (string.IsNullOrEmpty(_token))
                return Unauthorized();

            return Ok(new { Token = _token });
        }
    }
}
