using AllpFit.Library.Helpers;
using AllpFit.Library.Enumerators;
using System.Diagnostics.Contracts;
using AllpFit.Library.DomainEvents.Users.Contracts;
using AllpFit.Library.Exceptions;

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
        public string CPF { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public string Nationality { get; protected set; }
        public bool IsAdmin { get; protected set; }
        public string Password { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public byte IdStatus { get; protected set; }
        public User()
        { }

        public static User CreateUser(string name, string surname, string email, bool isAdmin, string password, string phoneNumber, string cpf, string nationality, DateTime birthDate) => new User(name, surname, email, isAdmin, password, phoneNumber, cpf, nationality, birthDate);

        private User(string name, string surname, string email, bool isAdmin, string password, string phoneNumber, string cpf, string nationality, DateTime birthDate)
        {
            if (!ValidateHelper.ValidateCPF(cpf))
                throw new DomainException("Formato do cpf é incorreto.");

            if(!ValidateHelper.ValidateEmail(email))
                throw new DomainException("Formato do email é incorreto.");

            if(!ValidateHelper.ValidatePhoneNumber(phoneNumber))
                throw new DomainException("Formato do telefone é incorreto.");

            IdUser = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Email = email;
            IsAdmin = isAdmin;
            Password = PasswordHelper.HashPassword(password);
            PhoneNumber = phoneNumber;
            Nationality = nationality;
            CPF = cpf;
            BirthDate = DateTimeHelper.DateTimeFromBrazil(birthDate);
            InsertDate = DateTime.Now.Brazil();
            IdStatus = (byte)Status.Active;
        }

        public void UpdateUser(string name, string surname, string email, string phoneNumber, string nationality, DateTime? birthDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = DateTimeHelper.DateTimeFromBrazil(birthDate);
            Nationality = nationality;
            UpdatedDate = DateTime.Now.Brazil();
        }

        public void UpdatePassword(string password)
        {
            Password = PasswordHelper.HashPassword(password);
            UpdatedDate = DateTime.Now.Brazil();
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
