using System.ComponentModel.DataAnnotations;

namespace ACV.ConditionReports.API.Models.Request
{
    public class UserLogin
    {
        [Required(ErrorMessage = "UserName is mandatory")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public required string Password { get; set; }
    }
}
