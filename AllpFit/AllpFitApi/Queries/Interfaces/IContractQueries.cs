using AllpFitApi.Models.Response;

namespace AllpFitApi.Queries.Interfaces
{
    public interface IContractQueries
    {
        Task<List<ListContractViewModel>> ListContractsAsync(Guid idUser);
    }
}
