using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.Interfaces.Repositories
{
    public interface IPatrimonioAtivosRepository
    {
        public Task<List<PatrimonioAtivos>> GetTopTrends(int quantidade);
        public Task<PatrimonioAtivos> GetPatrimonioAtivos(PatrimonioAtivos patrimonioAtivos);
        public Task<PatrimonioAtivos> CreatePatrimonioAtivos(PatrimonioAtivos patrimonioAtivos);
        public Task<PatrimonioAtivos> UpdatePatrimonioAtivos(PatrimonioAtivos patrimonioAtivos);
    }
}
