namespace AllpFitApi.Models.Response
{
    public class ListContractViewModel
    {
        public Guid IdContract { get; set; }
        public string PlanName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime RenewedDate { get; set; }
        public DateTime NextRenewDate { get; set; }
        public bool RecurrentPayment { get; set; } = false;
    }
}
