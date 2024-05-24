using AllpFit.Impl.Configuration;
using AllpFit.Library.Enumerators;
using AllpFitApi.Models.Response;
using AllpFitApi.Queries.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AllpFitApi.Queries.UserContext
{
    public class UserQueries : IUserQueries
    {
        #region read-only fields

        public readonly string _connectionString;

        #endregion

        #region Query Constants

        private const string GET_USER_QUERY = @"
            SELECT 
                u.IdUser,
                u.Name,
                u.Email,
                u.Password,
                u.IsAdmin,
                u.IdStatus,
                u.InsertDate,
                u.UpdatedDate
            FROM dbo.users u
            WHERE u.Email = @Email AND u.IdStatus <> @StatusDeleted";

        #endregion

        public UserQueries(IOptions<AppSettings> options)
        {
            _connectionString = options?.Value?.ConnectionString?.DefaultConnection ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<UserViewModel> GetUserInfo(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email.ToLowerInvariant());
            parameters.Add("@StatusDeleted", (byte)Status.Deleted);


            using (var connection = new MySqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<UserViewModel>(GET_USER_QUERY, parameters);
            }
        }


        #region Private Methods

        #endregion
    }
}
