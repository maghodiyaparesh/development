using AutoMapper;
using CrystalFlights.BO.BaseRepository;
using CrystalFlights.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrystalFlights.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<AirlineController> _logger;
        private IConfiguration _configuration;

        public AuthController(IRepositoryWrapper repoWrapper, IMapper mapper, ILogger<AirlineController> logger, IConfiguration configuration)
        {
            _repo = repoWrapper;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] UsersLogin usersLogin)
        {
            if (usersLogin == null)
            {
                return BadRequest("Invalid request");
            }

            var user = _repo.Users.AuthenticateUser(usersLogin).Result;

            if (user != null && user.IsActive)
            {
                return Ok(new { Token = GenerateJWTToken(user) });
            }
            else if(user != null && !user.IsActive)
            {
                return Problem("User is inactive. Please contact support team.");
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJWTToken(Users users)
        {
            var authOptions = _configuration.GetSection("AuthOptions").Get<AuthOptions>();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SecureKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: authOptions.Issuer,
                audience: authOptions.Audience,
                claims: new List<Claim>(new[] { new Claim("id", users.UserId.ToString()) }),
                expires: DateTime.Now.AddMinutes(authOptions.ExpiresInMinutes),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
    }
}
