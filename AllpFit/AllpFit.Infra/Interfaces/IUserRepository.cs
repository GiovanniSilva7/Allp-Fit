using AllpFit.Infra.Repositories;
using AllpFit.Library.Entities;

namespace AllpFit.Infra.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
