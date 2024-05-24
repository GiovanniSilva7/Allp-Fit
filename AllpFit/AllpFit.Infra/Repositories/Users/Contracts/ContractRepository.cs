using AllpFit.Infra.Context;
using AllpFit.Infra.Interfaces.Contracts;
using AllpFit.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Infra.Repositories.Users.Contracts
{
    public class ContractRepository : Repository<Contract, Guid>, IContractRepository
    {
        #region Read-only fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        public ContractRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

    }
}
