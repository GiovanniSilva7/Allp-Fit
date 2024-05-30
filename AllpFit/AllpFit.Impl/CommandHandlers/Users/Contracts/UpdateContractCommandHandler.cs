using AllpFit.Contracts.Commands.Users.Contracts;
using AllpFit.Infra.Interfaces.Contracts;
using AllpFit.Library.Enumerators;
using MediatR;

namespace AllpFit.Impl.CommandHandlers.Users.Contracts
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, UpdateContractCommand.Response>
    {
        #region Read-only fields

        private readonly IContractRepository _contractRepository;
        //TODO: Add logger and send the updated contract to the hub, Add TryCatch to handle exceptions

        #endregion

        public UpdateContractCommandHandler(IContractRepository contractRepository)
        {

            _contractRepository = contractRepository ?? throw new ArgumentNullException(nameof(contractRepository));

        }

        public async Task<UpdateContractCommand.Response> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _contractRepository.FirstOrDefaultAsync(x => x.IdUser == request.IdUser);

            if (contract == null)
                return UpdateContractCommand.Response.NotFound;

            contract.UpdateContract(request.IdPlan, request.StartDate, request.EndDate, request.IdRenewType, request.RecurrentPayment);

            await _contractRepository.UnitOfWork.SaveChangesAsync();
            return UpdateContractCommand.Response.Successfull;
        }
    }
}
