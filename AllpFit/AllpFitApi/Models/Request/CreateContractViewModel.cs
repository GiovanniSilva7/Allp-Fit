using System.ComponentModel.DataAnnotations;

namespace AllpFitApi.Models.Request
{
    public class CreateContractViewModel
    {
        [Required(ErrorMessage = "Usuário é necessário.")]
        public Guid IdUser { get; set; }

        [Required(ErrorMessage = "Selecionar um plano é necessário.")]
        public Guid IdPlan { get; set; }

        [Required(ErrorMessage = "Data de início é necessária.")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Tipo de renovação é necessário.")]
        public byte IdRenewType { get; set; }
    }
}
