using MediatR;
using System.Text.Json.Serialization;

namespace AllpFit.Library.DomainEvents
{
    public class BaseDomainEvent : INotification
    {
        public DateTime EventDate { get; protected set; }

        [JsonConstructor]
        public BaseDomainEvent()
        {
            EventDate = DateTime.Now;
        }

    }
}
