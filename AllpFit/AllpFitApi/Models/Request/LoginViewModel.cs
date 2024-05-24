using System.ComponentModel.DataAnnotations;

namespace AllpFitApi.Models.Request
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }
}
