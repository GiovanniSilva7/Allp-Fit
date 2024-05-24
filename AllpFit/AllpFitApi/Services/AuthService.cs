using AllpFitApi.Models.Response;
using AllpFitApi.Queries.Interfaces;
using AllpFitApi.Services.Interfaces;

namespace AllpFitApi.Services
{
    public class AuthService : IAuthService
    {
        #region read-only fields

        private IUserQueries _userQueries;

        #endregion

        public AuthService(IUserQueries userQueries)
        {
            _userQueries = userQueries ?? throw new ArgumentNullException(nameof(userQueries));
        }

        public async Task<UserViewModel> GetUserInfo(string email) => await _userQueries.GetUserInfo(email);
    }
}
