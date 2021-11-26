using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Interfaces.Services;

namespace ToroChallenge.Application.ApplicationServices
{
    public class AtivoApplicationService : IAtivoApplicationService
    {
        private readonly IAtivoService _service;
        private readonly IMapper _mapper;
        public AtivoApplicationService(IAtivoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<TrendResponse>> GetTopTrends()
        {
            var topAtivos = await _service.GetTopAtivos();
            return topAtivos.Select(ta => _mapper.Map<TrendResponse>(ta)).ToList();
        }
    }
}
