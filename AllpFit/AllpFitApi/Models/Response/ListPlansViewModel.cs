namespace AllpFitApi.Models.Response
{
    public class ListPlansViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public byte IdRenewType { get; set; }
    }
}
