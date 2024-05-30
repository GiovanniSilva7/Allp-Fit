using AllpFit.Library.Entities;

namespace AllpFit.Library.DomainEvents.Users.Contracts
{
    public class ContractAddedDomainEvent : BaseDomainEvent
    {
        #region Properties

        public Contract Contracts { get; private set; }

        #endregion

        public ContractAddedDomainEvent(Contract contracts)
        {
            Contracts = contracts;
        }

        //TODO: Add Domain Event Handlers

    }
}
