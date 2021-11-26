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
    public sealed class PatrimonioService : IPatrimonioService
    {
        private readonly IPatrimonioRepository _repository;
        public PatrimonioService(IPatrimonioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patrimonio> ObtenhaPatrimonioDoUsuario(int idUser)
        {
            var patrimonio = await _repository.ObtenhaPatrimonioDoUsuario(idUser);
            var sumarizadoAtivosNullable = patrimonio.PatrimonioAtivos?.Sum(pa => (pa.QuantidadeAtivos * pa.Ativo.CurrentPrice));
            var sumarizadoAtivos = sumarizadoAtivosNullable.HasValue ? sumarizadoAtivosNullable.Value : 0.0;
            patrimonio.Sumarizado = sumarizadoAtivos + patrimonio.Saldo;
            return patrimonio;
        }
    }
}
