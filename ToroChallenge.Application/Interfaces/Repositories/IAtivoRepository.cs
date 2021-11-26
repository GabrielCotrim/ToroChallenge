using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.Interfaces.Repositories
{
    public interface IAtivoRepository
    {
        public Task<List<Ativo>> GetAtivos();
        public Task<Ativo> GetAtivo(string symbol);
    }
}
