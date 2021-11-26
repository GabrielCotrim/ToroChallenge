using AutoMapper;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Interfaces.Services;

namespace ToroChallenge.Application.ApplicationServices
{
    public class PatrimonioApplicationService : IPatrimonioApplicationService
    {
        private readonly IPatrimonioService _service;
        private readonly IMapper _mapper;
        public PatrimonioApplicationService(IPatrimonioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<UserPositionResponse> ObtenhaPatrimonioDoUsuario(int idUser)
        {
            var patrimonio = await _service.ObtenhaPatrimonioDoUsuario(idUser);
            return _mapper.Map<UserPositionResponse>(patrimonio);
        }
    }
}
