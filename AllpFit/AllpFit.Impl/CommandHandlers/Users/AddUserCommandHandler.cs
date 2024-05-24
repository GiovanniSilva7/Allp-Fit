using AllpFit.Contracts.Commands.Users;
using AllpFit.Infra.Repositories;
using AllpFit.Library.Entities;
using MediatR;

namespace AllpFit.Impl.CommandHandlers.Users
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserCommand.Response>
    {
        #region Read-only fields

        private readonly IUserRepository _userRepository;
        //TODO: Add a logger

        #endregion

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<AddUserCommand.Response> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.AnyAsync(x => x.Email.Equals(request.Email, StringComparison.InvariantCultureIgnoreCase));

            if (user)
                return AddUserCommand.Response.AlreadyExists;

            var newUser = User.CreateUser(request.Name, request.Surname, request.Email, request.IsAdmin, request.Password, request.PhoneNumber);

            await _userRepository.AddAsync(newUser);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            return AddUserCommand.Response.Successfull;
        }
    }
}
