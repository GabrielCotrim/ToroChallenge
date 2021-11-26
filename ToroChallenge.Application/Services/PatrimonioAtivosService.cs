using System.Threading.Tasks;
using ToroChallenge.Application.Interfaces.Repositories;
using ToroChallenge.Application.Interfaces.Services;
using ToroChallenge.Application.Utils.Exceptions;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.Services
{
    public class PatrimonioAtivosService : IPatrimonioAtivosService
    {
        private readonly IPatrimonioAtivosRepository _repository;
        private readonly IAtivoRepository _ativoRepository;
        private readonly IPatrimonioRepository _patrimonioRepository;
        public PatrimonioAtivosService(IPatrimonioAtivosRepository repository, IAtivoRepository ativoRepository, IPatrimonioRepository patrimonioRepository)
        {
            _repository = repository;
            _ativoRepository = ativoRepository;
            _patrimonioRepository = patrimonioRepository;
        }

        public async Task<PatrimonioAtivos> CreateOrUpdatePatrimonioAtivos(PatrimonioAtivos patrimonioAtivos)
        {
            var patrimonio = await _patrimonioRepository.ObtenhaPatrimonioDoUsuario(patrimonioAtivos.Patrimonio.UsuarioId);
            var ativo = await _ativoRepository.GetAtivo(patrimonioAtivos.Ativo.Symbol);

            if (ativo == null) throw new NotFoundException();
            if (patrimonio == null) throw new NotFoundException();

            var patrimonioAtivosAtt = new PatrimonioAtivos { AtivoId = ativo.Id, PatrimonioId = patrimonio.Id, QuantidadeAtivos = patrimonioAtivos.QuantidadeAtivos };
            var patrimonioAtivosRep = await _repository.GetPatrimonioAtivos(patrimonioAtivosAtt);

            if (patrimonioAtivosRep == null) patrimonioAtivosRep = await _repository.CreatePatrimonioAtivos(patrimonioAtivosAtt);
            else
            {
                patrimonioAtivosRep.QuantidadeAtivos = patrimonioAtivosRep.QuantidadeAtivos += patrimonioAtivos.QuantidadeAtivos;
                patrimonioAtivosRep = await _repository.UpdatePatrimonioAtivos(patrimonioAtivosRep);
            }

            return patrimonioAtivosRep;
        }
    }
}
