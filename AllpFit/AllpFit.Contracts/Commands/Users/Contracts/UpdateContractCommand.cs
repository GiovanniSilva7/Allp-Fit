using AllpFit.Library.Entities;
using MediatR;

namespace AllpFit.Contracts.Commands.Users.Contracts
{
    
    public class UpdateContractCommand : IRequest<UpdateContractCommand.Response>
    {
        public enum Response
        {
            Successfull = 1,
            Error = 2,
            NotFound = 3
        }

        public UpdateContractCommand(Guid idUser, Contract contract)
        {
            IdUser = idUser;
            Contract = contract;
        }

        public Guid IdUser { get; private set; }
        public Guid IdPlan { get; private set; }
        public Contract Contract { get; set; }

    }
}
