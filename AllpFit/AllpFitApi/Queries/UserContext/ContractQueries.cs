using AllpFit.Impl.Configuration;
using AllpFit.Library.Enumerators;
using AllpFitApi.Models.Response;
using AllpFitApi.Queries.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace AllpFitApi.Queries.UserContext
{
    public class ContractQueries : IContractQueries
    {
        #region Read-only FIelds

        private readonly string _connectionString;

        #endregion

        #region Query Constants

        private const string LIST_CONTRACTS_QUERY = @"
            SELECT
                c.IdContract,
                p.PlanName,
                c.StartDate,
                c.EndDate,
                c.IdStatus,
                c.InsertDate,
                c.RenewedDate,
                c.NextRenewDate,
                c.RecurrentPayment
            FROM
                contracts c
                plans p ON c.IdPlan = p.IdPlan
            WHERE
                c.IdUser = @IdUser AND c.IdStatus <> @StatusDeleted
            ";

        #endregion

        public ContractQueries(IOptions<AppSettings> options)
        {
            _connectionString = options?.Value?.ConnectionStrings?.DefaultConnection ?? throw new System.ArgumentNullException(nameof(options));
        }

        public async Task<List<ListContractViewModel>> ListContractsAsync(Guid idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);
            parameters.Add("@StatusDeleted", (byte)Status.Deleted);

            using(var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<ListContractViewModel>(LIST_CONTRACTS_QUERY, parameters);
                return result.ToList();
            }
        }
    }
}
