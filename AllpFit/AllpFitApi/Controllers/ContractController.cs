using AllpFitApi.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AllpFitApi.Controllers
{
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
    }
}
