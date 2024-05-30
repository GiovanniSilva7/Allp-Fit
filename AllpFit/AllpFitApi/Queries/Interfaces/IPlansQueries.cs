using AllpFitApi.Models.Response;

namespace AllpFitApi.Queries.Interfaces
{
    public interface IPlansQueries
    {
        Task<List<ListPlansViewModel>> ListPlansAsync();
    }
}
