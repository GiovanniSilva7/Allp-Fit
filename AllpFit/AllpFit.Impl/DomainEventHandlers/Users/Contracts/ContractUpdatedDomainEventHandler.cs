using AllpFit.Contracts.Commands.Users.Contracts;
using AllpFit.Library.DomainEvents.Users.Contracts;
using MediatR;

namespace AllpFit.Impl.DomainEventHandlers.Users.Contracts
{
    public class ContractUpdatedDomainEventHandler : INotificationHandler<ContractUpdatedDomainEvent>
    {
        #region Read-only fields

        private readonly IMediator _mediator;

        #endregion

        public ContractUpdatedDomainEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(ContractUpdatedDomainEvent notification, CancellationToken cancellationToken) => await _mediator.Send(new UpdateContractCommand(notification.IdUser, notification.Contract));
    }
}
