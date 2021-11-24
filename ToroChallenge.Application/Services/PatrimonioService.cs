using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.Interfaces.Repositories;
using ToroChallenge.Application.Interfaces.Services;
using ToroChallenge.Domain.Models;

namespace ToroChallenge.Application.Services
{
    public sealed class PatrimonioService : IPatrimonioService
    {
        private readonly IPatrimonioRepository _repository;
        public PatrimonioService(IPatrimonioRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserPositionModel> ObtenhaPatrimonioDoUsuario(int idUser)
        {
            var patrimonio = await _repository.ObtenhaPatrimonioDoUsuario(idUser);
            var consolidatedNullable = patrimonio.PatrimonioAtivos?.Sum(pa => (pa.QuantidadeAtivos * pa.Ativo.CurrentPrice));
            var consolidated = consolidatedNullable.HasValue ? consolidatedNullable.Value : 0.0;
            var userPositionModel = new UserPositionModel
            {
                CheckingAccountAmount = patrimonio.Saldo,
                Positions = patrimonio.PatrimonioAtivos?.Select(pa => {
                    return new PositionModel
                    {
                        Amount = pa.QuantidadeAtivos,
                        Symbol = pa.Ativo.Symbol,
                        CurrentPrice = pa.Ativo.CurrentPrice
                    };
                }).ToList() ?? new List<PositionModel>(),
                Consolidated = consolidated
            };
            return userPositionModel;
        }
    }
}
