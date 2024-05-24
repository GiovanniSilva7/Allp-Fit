using AllpFit.Library.Enumerators;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllpFit.Library.Entities
{
    [Serializable]
    public class Contract : EntityBase
    {
        public Guid IdContract { get; protected set; }
        public byte IdContractType { get; protected set; }
        public decimal Price { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public byte IdStatus { get; protected set; }

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

        public static Contract CreateContract(ContractType contractType, decimal price, DateTime startDate, DateTime endDate) => new Contract(contractType, price, startDate, endDate);

        private Contract(ContractType contractType, decimal price, DateTime startDate, DateTime endDate)
        {
            IdContract = Guid.NewGuid();
            IdContractType = (byte)contractType;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            IdStatus = (byte)Status.Active;
            InsertDate = DateTime.Now;
        }

        public void UpdateContract(ContractType contractType, decimal price, DateTime startDate, DateTime endDate)
        {
            IdContractType = (byte)contractType;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            UpdatedDate = DateTime.Now;
        }

        public void DeleteContract()
        {
            if (IdStatus == (byte)Status.Deleted)
                return;

            IdStatus = (byte)Status.Deleted;
            UpdatedDate = DateTime.Now;
        }
    }
}
