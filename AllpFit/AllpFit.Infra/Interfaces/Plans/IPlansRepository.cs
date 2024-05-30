using AllpFit.Infra.Repositories;
using Entity = AllpFit.Library.Entities;

namespace AllpFit.Infra.Interfaces.Plans
{
    public interface IPlansRepository : IRepository<Entity.Plans, Guid>
    {
    }
}
