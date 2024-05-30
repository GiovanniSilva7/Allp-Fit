using System.Globalization;

namespace AllpFitApi.Models.Request
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; } = "Brasileiro(a)";
        public bool IsAdmin { get; set; } = false;
    }
}
