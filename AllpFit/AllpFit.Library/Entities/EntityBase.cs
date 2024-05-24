using MediatR;

namespace AllpFit.Library.Entities
{
    [Serializable]
    public abstract class EntityBase
    {
        public EntityBase()
        {}

        public DateTime InsertDate { get; protected set; }
        public DateTime? UpdatedDate { get; protected set; }

                //Give me a method that can send domain events with MediatR
        public void SendDomainEvent(INotification domainEvent)
        {
            //I'm a method
        }
        //Give me a method that can remove domain events with MediatR
        public void RemoveDomainEvent(INotification domainEvent)
        {
            //I'm a method
        }
        //Give me a method that can clear domain events with MediatR
        public void ClearDomainEvents()
        {
            //I'm a method
        }
    }
}
