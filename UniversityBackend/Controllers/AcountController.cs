using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniversityBackend.Helpers;
using UniversityBackend.Models.DataModels;
using UniversityBackend.DataAcces;
namespace UniversityBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        public AccountController(UniversityDBContext context ,JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _context = context;
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
        public async IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                var token = new UserTokens();

                var user = await _context.Users.FindAsync(userLogin.UserName);

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public IActionResult GetUserList()
        {
            return Ok(Logins);
        } 
        
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public IActionResult GetUserGood()
        {
            var linq = from user in _context.Users
                       where user.name == "Alvaro"
                       select user;
            return (IActionResult)linq;
        }
       
    }
}
