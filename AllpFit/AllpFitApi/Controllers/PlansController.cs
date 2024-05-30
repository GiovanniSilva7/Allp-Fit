using AllpFitApi.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AllpFitApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ControllerBase
    {
        #region Read-only fields

        private readonly IPlansQueries _plansQueries;

        #endregion

        public PlansController(IPlansQueries plansQueries)
        {
            _plansQueries = plansQueries ?? throw new ArgumentNullException(nameof(plansQueries));
        }

        public async Task<IActionResult> ListPlansAsync()
        {
            var result = await _plansQueries.ListPlansAsync();

            return Ok(result);
        }
    }
}
