using AllpFit.Contracts.Commands.Users;
using AllpFitApi.Models.Request;
using AllpFitApi.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AllpFitApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        #region Read-only Fields

        private readonly IUserQueries _userQueries;
        private readonly IMediator _mediator;

        #endregion
        public UserController(IUserQueries userQueries, IMediator mediator)
        {
            _userQueries = userQueries ?? throw new ArgumentNullException(nameof(userQueries));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IActionResult> CreateUser([FromQuery]CreateUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var command = new AddUserCommand(userModel.Name, userModel.Surname, userModel.Email, userModel.Password, userModel.PhoneNumber, userModel.CPF, userModel.BirthDate, 
                                  userModel.Nationality, userModel.IsAdmin);

                var result = await _mediator.Send(command);

                switch (result)
                {
                    case AddUserCommand.Response.Successfull:
                        return Ok("Usuário criado com sucesso!");
                    case AddUserCommand.Response.AlreadyExists:
                        return BadRequest("Usuário já existente");
                    case AddUserCommand.Response.WrongFormatCPF:
                        return BadRequest("CPF inválido");
                    case AddUserCommand.Response.Error:
                        return BadRequest("Erro ao criar usuário");
                }

            }
                return BadRequest("Erro ao criar usuário");
        }
    }
}
