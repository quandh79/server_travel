using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server_travel.Dtos.Authentication;
using server_travel.Entities;
using server_travel.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TravelApiContext _context;
        private readonly IConfiguration _config;
        public AuthenticationController(TravelApiContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegisterRequest request)
        {
           var hashed = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashed,
                RoleTitle = "user"
            };
            _context.Users.Add(user);
             _context.SaveChanges();
            return  Ok(new UserViewModel { Name = request.Name, Email = request.Email, Token = GenerateJWT(user) });
        }

        private String GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                //new Claim(ClaimTypes.Role,user.RoleTitle),
                //new Claim("IT",user.JobTitle)
            };
            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signatureKey
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("login")]
        public  IActionResult Login(UserLoginRequest request)
        {
            var user =   _context.Users.Where(u=>u.Email.Equals(request.Email)).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }
            bool veryfied = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (!veryfied)
            {
                return Unauthorized();
            }
            return Ok(new UserViewModel { Id = user.Id, Name = user.Name, Email = user.Email, Token = GenerateJWT(user) });
        }
    }
}
