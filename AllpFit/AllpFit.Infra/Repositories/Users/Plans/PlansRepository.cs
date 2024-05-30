using AllpFit.Infra.Context;
using AllpFit.Infra.Interfaces.Plans;
using Entity = AllpFit.Library.Entities;
        
namespace AllpFit.Infra.Repositories.Users.Plans
{
    public class PlansRepository : Repository<Entity.Plans, Guid>, IPlansRepository
    {
        public PlansRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
