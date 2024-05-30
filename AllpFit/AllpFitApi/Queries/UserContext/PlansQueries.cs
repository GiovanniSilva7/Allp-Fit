using AllpFit.Impl.Configuration;
using AllpFit.Library.Enumerators;
using AllpFitApi.Models.Response;
using AllpFitApi.Queries.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System.Linq.Expressions;

namespace AllpFitApi.Queries.UserContext
{
    public class PlansQueries : IPlansQueries
    {

        #region Query Constants

        private readonly string LIST_PLANS_QUERY = @"
            SELECT DISTINCT
                IdPlan,
                PlanName,
                Description,
                Value,
                IdContractType
            FROM
                plans
            WHERE
                IdStatus = @StatusActive";

        #endregion

        #region Readonly fields

        private readonly string _connectionString;

        #endregion

        public PlansQueries(IOptions<AppSettings> options)
        {
            _connectionString = options?.Value?.ConnectionStrings?.DefaultConnection ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task<List<ListPlansViewModel>> ListPlansAsync()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@StatusActive", (byte)Status.Active);

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<ListPlansViewModel>(LIST_PLANS_QUERY, parameters);

                return result.ToList();
            }
        }
    }
}
