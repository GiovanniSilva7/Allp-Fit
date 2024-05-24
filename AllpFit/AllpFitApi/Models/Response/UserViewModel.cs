namespace AllpFitApi.Models.Response
{
    public class UserViewModel
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public byte IdStatus { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
