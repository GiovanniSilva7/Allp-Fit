using MediatR;

namespace AllpFit.Contracts.Commands.Users
{
    public class AddUserCommand : IRequest<AddUserCommand.Response>
    {

        public enum Response
        {
            Successfull = 1,
            AlreadyExists = 2,
            Error = 3
        }

        public AddUserCommand(string name, string surname, string email, string password, string phoneNumber, bool isAdmin = false)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            PhoneNumber = phoneNumber;
        }

        #region Properties

        public string Name { get; private set; }
        public string Surname { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public string PhoneNumber { get; private set; }

        #endregion

    }
}
