using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using E_Library.Model;
namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : Controller
    {
        public static AdminRegister admin = new AdminRegister();
        private readonly IConfiguration _config;
        public AdminAuthController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AdminRegister>> Register(AdminDto request)
        {
            CreatePasswordHash(request.admin_Password, out byte[] admin_passwordHash, out byte[] admin_passwordSalt);
            admin.admin_username = request.admin_Username;
            admin.admin_passwordhash = admin_passwordHash;
            admin.admin_passwordsalt = admin_passwordSalt;

            return Ok(admin);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AdminDto request)
        {
            if (admin.admin_username != request.admin_Username)
            {
                return BadRequest("Username khong tim thay");
            }
            if (!VerifyPasswordHash(request.admin_Password, admin.admin_passwordsalt, admin.admin_passwordhash))
            {
                return BadRequest("Sai mat khau");
            }
            string token = CreatedToken(admin);
            return Ok(token);
        }
        public string CreatedToken(AdminRegister adminRegister)
        {
            List<Claim> claims = new List<Claim>();
            {
                new Claim(ClaimTypes.Name, admin.admin_username);
                new Claim(ClaimTypes.Role, "admin");
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims,
                                             expires: DateTime.Now.AddDays(1),
                                             signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private void CreatePasswordHash(string admin_password, out byte[] admin_passwordHash, out byte[] admin_passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                admin_passwordSalt = hmac.Key;
                admin_passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(admin_password));
            }
        }

        private bool VerifyPasswordHash(string admin_password, byte[] admin_passwordHash, byte[] admin_passwordSalt)
        {
            using (var hmac = new HMACSHA512(admin_passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(admin_password));
                return computedHash.SequenceEqual(admin_passwordHash);
            }
        }
    }
}

