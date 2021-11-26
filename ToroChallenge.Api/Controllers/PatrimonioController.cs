using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Utils.Exceptions;

namespace ToroChallenge.Api.Controllers
{
    [Route("api/patrimonio")]
    [ApiController]
    public class PatrimonioController : ControllerBase
    {
        private readonly IPatrimonioApplicationService _applicationService;
        public PatrimonioController(IPatrimonioApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Route("userPosition")]
        [Produces("application/json")]
        public async Task<ActionResult<UserPositionResponse>> GetUserPosition([FromQuery] int id)
        {
            try
            {
                var userPosition = await _applicationService.ObtenhaPatrimonioDoUsuario(id);
                return Ok(userPosition);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
