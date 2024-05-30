using AllpFit.Library.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Contracts.Commands.Users.Contracts
{
    public class CreateContractCommand : IRequest<CreateContractCommand.Response>
    {

        #region Response
        public enum Response 
        {             
            Success = 1,
            Error = 2,
            SameContract = 3,
            InvalidContract = 4,
        }

        #endregion

        #region Properties

        public Guid IdUser { get; private set; }
        public Guid IdPlan { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public byte IdRenewType { get; private set; }
        public bool RecurrentPayment { get; private set; }

        public CreateContractCommand(Guid idUser, Guid idPlan, DateTime startDate, DateTime endDate, byte idRenewType = (byte)RenewType.Test, bool recurrentPayment = false)
        {
            IdUser = idUser;
            IdPlan = idPlan;
            StartDate = startDate;
            EndDate = endDate;
            IdRenewType = idRenewType;
            RecurrentPayment = recurrentPayment;
        }



        #endregion

    }
}
