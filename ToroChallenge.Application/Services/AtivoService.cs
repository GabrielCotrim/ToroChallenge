using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.Interfaces.Repositories;
using ToroChallenge.Application.Interfaces.Services;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.Services
{
    public class AtivoService : IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly IPatrimonioAtivosRepository _patrimonioAtivosRepository;
        public AtivoService(IAtivoRepository ativoRepository, IPatrimonioAtivosRepository patrimonioAtivosRepository)
        {
            _ativoRepository = ativoRepository;
            _patrimonioAtivosRepository = patrimonioAtivosRepository;
        }

        public async Task<List<Ativo>> GetTopAtivos()
        {
            const int quantidade = 5;
            var topPatrimonioAtivos = await _patrimonioAtivosRepository.GetTopTrends(5);
            var topAtivos = topPatrimonioAtivos.Select(pa => pa.Ativo).ToList();
            var quantidadeTopAtivos = topAtivos.Count;
            if (quantidadeTopAtivos < quantidade)
            {
                var resto = quantidade - quantidadeTopAtivos;
                var ativos = await _ativoRepository.GetAtivos();
                topAtivos.AddRange(ativos.Where(a => !topAtivos.Any(ta => ta.Equals(a))).Take(resto));
            }
            return topAtivos;
        }
    }
}
