using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityBackend.Helpers;
using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id=1,
                email="admin@admin.es",
                name="Admin",
                password="admin"
            },new User()
            {
                Id=2,
                email="user@admin.es",
                name="User",
                password="user"
            }
        };
        [HttpPost]
        public IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                var token = new UserTokens();
                var valid = Logins.Any(user => user.name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (valid)
                {
                    var user = Logins.FirstOrDefault(user => user.name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName = user.name,
                        EmailId = user.email,
                        Id = user.Id,
                        GuiId = Guid.NewGuid()
                    },_jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong PW");
                }
                return Ok(token);

            }
            catch(Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
       
    }
}
