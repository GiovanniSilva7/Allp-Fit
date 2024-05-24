using AllpFitApi.Models.Response;

namespace AllpFitApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserViewModel> GetUserInfoAsync(string email);
    }
}
