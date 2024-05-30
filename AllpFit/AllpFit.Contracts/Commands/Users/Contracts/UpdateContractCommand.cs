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

        public UpdateContractCommand(Guid idUser, Guid idPlan, DateTime startDate, DateTime endDate, byte idRenewType, bool isRecurrentPayment = false)
        {
            IdUser = idUser;
            IdPlan = idPlan;
            StartDate = startDate;
            EndDate = endDate;
            IdRenewType = idRenewType;
            RecurrentPayment = isRecurrentPayment;
        }

        public Guid IdUser { get; private set; }
        public Guid IdPlan { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public byte IdRenewType { get; private set; }
        public bool RecurrentPayment { get; private set; }

    }
}
