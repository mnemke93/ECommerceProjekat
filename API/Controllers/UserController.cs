using Application.UseCases.Commands;
using Application.UseCases.DTO;
using Application.UseCases.Services;
using Domain.Entities;
using IdentityServer3.Core.Services;
using Implementation;
using Implementation.UseCases.Commands;
using Implementation.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private UseCaseHandler _handler;
        private ILoginUserService _userLoginService;

        public UserController(UseCaseHandler handler, ILoginUserService service)
        {
            _handler = handler;
            _userLoginService = service;
        }

        // POST api/<UserController>
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterUserDTO dto,
            [FromServices] IRegisterUserCommand command,
            [FromServices] RegisterUserValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    return UnprocessableEntity(result.Errors.Select(x => new
                    {
                        x.ErrorMessage,
                        x.PropertyName
                    }));
                }
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateUserDTO dto,
            [FromServices] IUpdateUserCommand command,
            [FromServices] UpdateUserValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    return UnprocessableEntity(result.Errors.Select(x => new
                    {
                        x.ErrorMessage,
                        x.PropertyName
                    }));
                }
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] DeleteUserDTO dto,
            [FromServices] IDeleteUserCommand command,
            [FromServices] DeleteUserValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    return UnprocessableEntity(result.Errors.Select(x => new
                    {
                        x.ErrorMessage,
                        x.PropertyName
                    }));
                }
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var user = await _userLoginService.GetByEmail(dto.Email);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            // Check password using bcrypt
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return BadRequest(new { message = "Email or password is incorrect" });

            // generate token if authentication was successful
            var tokenString = GenerateJwtToken(user);

            return Ok(new
            {
                ID = user.ID,
                Email = user.Email,
                Token = tokenString
            });
        }

        // Method to generate JWT token
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Configuration[\"JwtConfig:secret\"]");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, user.Email.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
