using AllpFit.Library.DomainEvents.Users.Contracts;
using AllpFit.Library.Enumerators;
using AllpFit.Library.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllpFit.Library.Entities
{
    [Serializable]
    public class Contract : EntityBase
    {
        public Guid IdContract { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime RenewedDate { get; protected set; }
        public DateTime NextRenewDate { get; protected set; }
        public byte IdRenewType { get; protected set; }
        public byte IdStatus { get; protected set; }
        public bool RecurrentPayment { get; protected set; } = false;

        #region Navigation Properties

        [ForeignKey("IdUser")]
        public Guid IdUser { get; protected set; }
        public User User { get; protected set; }

        [ForeignKey("Plan")]
        public Guid IdPlan { get; protected set; }
        public Plans Plan { get; protected set; }

        #endregion

        public Contract()
        { }

        public static Contract CreateContract(Guid idPlan, Guid idUser, DateTime startDate, DateTime endDate, byte idRenewType = (byte)RenewType.Monthly, bool recurrentPayment = false) => new Contract(idPlan, idUser, startDate, endDate, idRenewType, recurrentPayment);

        private Contract(Guid idPlan, Guid idUser, DateTime startDate, DateTime endDate, byte idRenewType, bool recurrentPayment = false)
        {
            IdContract = Guid.NewGuid();
            StartDate = DateTimeHelper.DateTimeFromBrazil(startDate);
            EndDate = DateTimeHelper.DateTimeFromBrazil(endDate);
            IdUser = idUser;
            IdPlan = idPlan;
            RecurrentPayment = recurrentPayment;
            IdStatus = (byte)Status.Active;
            IdRenewType = idRenewType;

            switch (idRenewType)
            {
                case (byte)RenewType.Monthly:
                    RenewedDate = StartDate.AddMonths(1);
                    NextRenewDate = StartDate.AddMonths(2);
                    break;

                case (byte)RenewType.Yearly:
                    RenewedDate = StartDate.AddYears(1);
                    NextRenewDate = StartDate.AddYears(2);
                    break;
            }

            InsertDate = DateTime.Now.Brazil();
            SendDomainEvent(new ContractAddedDomainEvent(this));
        }

        public void UpdateContract(Guid idPlan, DateTime startDate, DateTime endDate, byte idRenewType, bool recurrentPayment = false)
        {
            IdPlan = idPlan;
            StartDate = DateTimeHelper.DateTimeFromBrazil(startDate);
            EndDate = DateTimeHelper.DateTimeFromBrazil(endDate);
            IdRenewType = idRenewType;
            RecurrentPayment = recurrentPayment;
            UpdatedDate = DateTime.Now.Brazil();
        }

        public void DeleteContract()
        {
            if (IdStatus == (byte)Status.Deleted)
                return;

            IdStatus = (byte)Status.Deleted;
            UpdatedDate = DateTime.Now.Brazil();
        }

        public void DeactivateRecurrentPayment()
        {
            RecurrentPayment = false;
            UpdatedDate = DateTime.Now.Brazil();
        }
    }
}
