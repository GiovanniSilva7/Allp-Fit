using AllpFit.Contracts.Commands.Users.Contracts;
using AllpFit.Infra.Interfaces.Contracts;
using AllpFit.Library.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Impl.CommandHandlers.Users.Contracts
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, CreateContractCommand.Response>
    {
        #region Read-only fields

        private readonly IContractRepository _contractRepository;

        //TODO: Add Loger

        #endregion

        public CreateContractCommandHandler(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository ?? throw new ArgumentNullException(nameof(contractRepository));
        }

        public async Task<CreateContractCommand.Response> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.FirstOrDefaultNoTrackingAsync(x => x.IdPlan == request.IdPlan);

            if(contract != null)
                return CreateContractCommand.Response.SameContract;

            var newContract = Contract.CreateContract(request.IdUser, request.IdPlan, request.StartDate, request.EndDate, request.IdRenewType, request.RecurrentPayment);

            await _contractRepository.AddAsync(newContract);
            await _contractRepository.UnitOfWork.SaveChangesAsync();
            return CreateContractCommand.Response.Success;
        }
    }
}
