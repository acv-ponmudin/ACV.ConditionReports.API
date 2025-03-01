using ACV.ConditionReports.API.Helpers;
using ACV.ConditionReports.API.Models.DTOs;
using ACV.ConditionReports.API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ACV.ConditionReports.API.Services
{
    public class AuthService : IAuthService
    {
        JwtSetting _jwtSetting;

        public AuthService(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
        }

        public async Task<string> Login(string username, string password)
        {
            try
            {
                if (username == "conditionreports" && password == "070f8286-02b5-4513-bfe7-219687b32be8")
                    return Utils.GenerateJwtToken(username, _jwtSetting);
            }
            catch (Exception)
            {
                throw;
            }

            return "";
        }
    }
}
