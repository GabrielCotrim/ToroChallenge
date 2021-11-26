using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Utils.Exceptions;

namespace ToroChallenge.Api.Controllers
{
    [Route("api/ativo")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoApplicationService _applicationService;
        public AtivoController(IAtivoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Route("trends")]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TrendResponse>>> GetTopTrends()
        {
            try
            {
                var trends = await _applicationService.GetTopTrends();
                return Ok(trends);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
