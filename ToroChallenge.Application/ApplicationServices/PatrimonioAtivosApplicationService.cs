using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Requests;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Interfaces.Services;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.ApplicationServices
{
    public class PatrimonioAtivosApplicationService : IPatrimonioAtivosApplicationService
    {
        private readonly IPatrimonioAtivosService _service;
        private readonly IMapper _mapper;
        public PatrimonioAtivosApplicationService(IPatrimonioAtivosService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<PositionReponse> CreateOrUpdatePatrimonioAtivos(int idUser, OrderRequest order)
        {
            var patrimonioAtivosRequest = _mapper.Map<PatrimonioAtivos>(order);
            patrimonioAtivosRequest.Patrimonio = new Patrimonio { UsuarioId = idUser };
            var patrimonioAtivos = await _service.CreateOrUpdatePatrimonioAtivos(patrimonioAtivosRequest);
            return _mapper.Map<PositionReponse>(patrimonioAtivos);
        }
    }
}
