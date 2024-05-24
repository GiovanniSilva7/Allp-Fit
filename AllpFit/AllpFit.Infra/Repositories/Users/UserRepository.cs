using AllpFit.Infra.Context;
using AllpFit.Infra.Interfaces;
using AllpFit.Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Infra.Repositories.Users
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        #region Read-only fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

       
    }
}
