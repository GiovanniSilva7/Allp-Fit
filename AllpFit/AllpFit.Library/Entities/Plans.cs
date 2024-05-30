using AllpFit.Library.Enumerators;
using AllpFit.Library.Helpers;

namespace AllpFit.Library.Entities
{
    public class Plans : EntityBase
    {
        public Guid IdPlan { get; protected set; }
        public string PlanName { get; protected set; }
        public decimal Value { get; protected set; }
        public string Description { get; protected set; }
        public byte IdStatus { get; protected set; }
        public byte IdContractType { get; protected set; }
        public List<Contract> Contracts { get; protected set; }

        protected Plans()
        {}

        public static Plans CreatePlan(string planName, decimal value, string description, byte idContractType) => new Plans(planName, value, description, idContractType);

        public Plans(string planName, decimal value, string description, byte idContractType = (byte)ContractType.Basic)
        {
            IdPlan = Guid.NewGuid();
            PlanName = planName;
            Value = value;
            Description = description;
            IdContractType = idContractType;
            InsertDate = DateTime.Now.Brazil();
            IdStatus = (byte)Status.Active;
        }

        public void UpdatePlan(string planName, decimal value, string description, byte idContractType)
        {
            PlanName = planName;
            Value = value;
            Description = description;
            UpdatedDate = DateTime.Now.Brazil();
        }

        public void DeletePlan()
        {
            if (IdStatus == (byte)Status.Deleted)
                return;

            IdStatus = (byte)Status.Deleted;
            UpdatedDate = DateTime.Now.Brazil();
        }
    }
}
