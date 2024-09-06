using ColoradoCrud.Api.Application.DTOs;
using ColoradoCrud.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ColoradoCrud.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _configuration;

        public AutenticacaoController(UserManager<Usuario> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, dto.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                var tokenResponse = new TokenDto
                {
                    Token = tokenString,
                    Expiration = token.ValidTo
                };

                return Ok(tokenResponse);
            }

            return Unauthorized(new { message = "Credenciais inválidas" });
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new Usuario
                {
                    UserName = model.Username,
                    Email = model.Username, 
                    Nome = model.Nome,
                    DataNascimento = model.DataNascimento
                };

                var result = await _userManager.CreateAsync(user, model.Senha);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Usuário registrado com sucesso!" });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest("Dados inválidos");
        }
    }
}
