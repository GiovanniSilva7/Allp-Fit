using AllpFitApi.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AllpFitApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        #region Read-only Fields

        private readonly IContractQueries _contractQueries;
        private readonly IMediator _mediator;
        //TODO: Add Logger

        #endregion

        public ContractController(IContractQueries contractQueries, IMediator mediator)
        {
            _contractQueries = contractQueries ?? throw new ArgumentNullException(nameof(contractQueries));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //TODO: Implementar métodos
        public async Task<IActionResult> ListContracts()
        {
            var idUser = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type.Equals("IdUser", StringComparison.Ordinal))?.Value);

            if (idUser.Equals(Guid.Empty))
                return BadRequest("Id do usuário inválido");

            var result = await _contractQueries.ListContractsAsync(idUser);

            return Ok(result);
        }
    }
}
