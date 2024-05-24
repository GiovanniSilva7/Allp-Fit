using AllpFit.Library.Helpers;
using AllpFit.Library.Enumerators;
using System.Diagnostics.Contracts;
using AllpFit.Library.DomainEvents.Users.Contracts;

namespace AllpFit.Library.Entities
{
    [Serializable]
    public class User : EntityBase
    {
        public Guid IdUser { get; protected set; }
        public Contract Contract { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Email { get; protected set; }
        public bool IsAdmin { get; protected set; }
        public string Password { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public byte IdStatus { get; protected set; }
        public User()
        { }

        public static User CreateUser(string name, string surname, string email, bool isAdmin, string password, string phoneNumber) => new User(name, surname, email, isAdmin, password, phoneNumber);

        private User(string name, string surname, string email, bool isAdmin, string password, string phoneNumber)
        {
            IdUser = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            IsAdmin = isAdmin;
            Password = PasswordHelper.HashPassword(password);
            PhoneNumber = phoneNumber;
            InsertDate = DateTime.Now;
            IdStatus = (byte)Status.Active;
        }

        public void UpdateUser(string name, string surname, string email, bool isAdmin, string password, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            IsAdmin = isAdmin;
            Password = password;
            PhoneNumber = phoneNumber;
            UpdatedDate = DateTime.Now;
        }
        public void DeleteUser()
        {
            if (IdStatus == (byte)Status.Deleted)
                return;

            IdStatus = (byte)Status.Deleted;
        }

        public void UpdateContract(Contract contract)
        {
            Contract = contract;

            SendDomainEvent(new ContractUpdatedDomainEvent(IdUser, contract));
        }

        private bool ValidateUser(string name, string email, string phoneNumber)
        {
            return Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) ||
                   Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) ||
                   PhoneNumber.Equals(phoneNumber, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
