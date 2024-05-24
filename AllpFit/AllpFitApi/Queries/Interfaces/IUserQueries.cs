using AllpFitApi.Models.Response;

namespace AllpFitApi.Queries.Interfaces
{
    public interface IUserQueries
    {
        Task<UserViewModel> GetUserInfo(string email);
    }
}
