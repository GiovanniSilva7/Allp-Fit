using AllpFit.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Library.DomainEvents.Users.Contracts
{
    public class ContractUpdatedDomainEvent : BaseDomainEvent
    {
        public Guid IdUser { get; set; }
        public Contract Contract { get; set; }

        public ContractUpdatedDomainEvent(Guid idUser, Contract updateContract)
        {
            IdUser = idUser;
            Contract = updateContract;
        }

        //TODO: Add Domain Event Handlers
    }
}
