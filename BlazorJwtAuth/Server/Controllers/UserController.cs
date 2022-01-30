using BlazorJwtAuth.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorJwtAuth.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly JwtSettings _jwtSettings;

    private static readonly List<RegisterDto> _users = new()
    {
        new RegisterDto("test", "123", new string[0]),
    };

    public UserController(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto login)
    {
        var user = _users
            .Where(r => r.Name == login.Name)
            .Where(r => r.Password == login.Password)
            .SingleOrDefault();

        if (user == null)
            return BadRequest(new LoginResult(false, Error: "User name or password are invalid."));

        var stringToken = GetStringToken(user);
        return Ok(new LoginResult(true, Token: stringToken));
    }


    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto register)
    {
        if (_users.Any(r => r.Name == register.Name))
            return BadRequest(new RegisterResult(false, "User already registered"));

        _users.Add(register);

        return Ok(new RegisterResult(true));
    }


    private string GetStringToken(RegisterDto user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
        };

        if (user.Roles.Any())
        {
            foreach (var role in user.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var creds = new SigningCredentials(_jwtSettings.SigningKey, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddSeconds(10); //DateTime.Now.AddDays(_jwtSettings.ExpiryInDays);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expiry,
            signingCredentials: creds
        );
        var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
        return stringToken;
    }
}

