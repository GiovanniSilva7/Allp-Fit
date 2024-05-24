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
        public List<Contract> Contracts { get; set; }

        public Plans()
        {}

        public static Plans CreatePlan(string planName, decimal value, string description) => new Plans(planName, value, description);

        public Plans(string planName, decimal value, string description)
        {
            IdPlan = Guid.NewGuid();
            PlanName = planName;
            Value = value;
            Description = description;
            InsertDate = DateTime.Now.Brazil();
            IdStatus = (byte)Status.Active;
        }

        public void UpdatePlan(string planName, decimal value, string description)
        {
            PlanName = planName;
            Value = value;
            Description = description;
            UpdatedDate = DateTime.Now.Brazil();
        }
    }
}
