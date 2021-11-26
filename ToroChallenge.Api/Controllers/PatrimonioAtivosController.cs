using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Requests;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Utils.Exceptions;

namespace ToroChallenge.Api.Controllers
{
    [Route("api/ativo")]
    [ApiController]
    public class PatrimonioAtivosController : ControllerBase
    {
        private readonly IPatrimonioAtivosApplicationService _applicationService;
        public PatrimonioAtivosController(IPatrimonioAtivosApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [Route("order")]
        [Produces("application/json")]
        public async Task<ActionResult<PositionReponse>> PostOrder([FromQuery] int id, [FromBody] OrderRequest order)
        {
            try
            {
                var orderSuccess = await _applicationService.CreateOrUpdatePatrimonioAtivos(id, order);
                return Ok(orderSuccess);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
