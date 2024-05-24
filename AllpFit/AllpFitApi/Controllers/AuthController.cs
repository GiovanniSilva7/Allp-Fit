using AllpFit.Contracts.Commands.Users;
using AllpFit.Impl.Configuration;
using AllpFit.Library.Helpers;
using AllpFitApi.Models.Request;
using AllpFitApi.Models.Response;
using AllpFitApi.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace AllpFitApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("{controller}")]
    public class AuthController : ControllerBase
    {
        #region read-only fields

        private readonly IAuthService _authService;
        private readonly AppSettings _settings;
        private readonly IMediator _mediator;

        #endregion

        public AuthController(IAuthService authService, IOptions<AppSettings> settings, IMediator mediator)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var user = await _authService.GetUserInfo(model.Email);

                if (user is null || !PasswordHelper.VerifyPassword(model.Password, user.Password))
                    return BadRequest("Email e/ou Senha incorretos!");

                return Ok(new { Token = GenerateToken(user) });
            }

            return BadRequest(ModelState.Values);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new AddUserCommand(model.Name, model.Surname, model.Email, model.Password, model.PhoneNumber);
                var result = await _mediator.Send(command);

                switch (result)
                {
                    case AddUserCommand.Response.Successfull:
                        return Ok("Usuário cadastrado com sucesso!");
                    case AddUserCommand.Response.AlreadyExists:
                        return BadRequest("Usuário já cadastrado!");
                    case AddUserCommand.Response.Error:
                        return BadRequest("Erro ao cadastrar usuário!");
                    default:
                        return BadRequest("Erro ao cadastrar usuário!");
                }
            }

            return BadRequest(ModelState.Values);
        }

        #region Private Methods

        private string GenerateToken(UserViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings?.AuthSettings?.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User"),
                new Claim(nameof(user.IdUser), user.IdUser.ToString()),
                new Claim(nameof(user.Name), user.Name),
                new Claim(nameof(user.Surname), user.Surname),
                new Claim(nameof(user.Email), user.Email),
            };

            var token = new JwtSecurityToken(_settings?.AuthSettings?.Issuer,
                                         _settings?.AuthSettings?.Audience,
                                         expires: DateTime.Now.AddHours(5),
                                         signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
    }
}
