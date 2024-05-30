using AllpFit.Library.Enumerators;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllpFit.Library.Entities
{
    [Serializable]
    public class Contract : EntityBase
    {
        public Guid IdContract { get; protected set; }
        public decimal Price { get; protected set; }
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

        public static Contract CreateContract(Guid idPlan, decimal price, DateTime startDate, DateTime endDate, byte idRenewType = (byte)RenewType.Monthly, bool recurrentPayment = false) => new Contract(idPlan, price, startDate, endDate, idRenewType, recurrentPayment);

        private Contract(Guid idPlan, decimal price, DateTime startDate, DateTime endDate, byte idRenewType, bool recurrentPayment = false)
        {
            IdContract = Guid.NewGuid();
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
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

            InsertDate = DateTime.Now;
        }

        public void UpdateContract(Guid idPlan, decimal price, DateTime startDate, DateTime endDate, bool recurrentPayment = false)
        {
            IdPlan = idPlan;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            RecurrentPayment = recurrentPayment;
            UpdatedDate = DateTime.Now;
        }

        public void DeleteContract()
        {
            if (IdStatus == (byte)Status.Deleted)
                return;

            IdStatus = (byte)Status.Deleted;
            UpdatedDate = DateTime.Now;
        }

        public void DeactivateRecurrentPayment()
        {
            RecurrentPayment = false;
            UpdatedDate = DateTime.Now;
        }
    }
}
