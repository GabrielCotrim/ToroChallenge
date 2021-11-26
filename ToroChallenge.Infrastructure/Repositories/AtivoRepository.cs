using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.Interfaces.Repositories;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Infrastructure.Data;

namespace ToroChallenge.Infrastructure.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AtivoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Ativo> GetAtivo(string symbol)
        {
            return _dbContext.Ativos.FirstOrDefaultAsync(a => a.Symbol == symbol);
        }

        public Task<List<Ativo>> GetAtivos()
        {
            return Task.FromResult(_dbContext.Ativos.ToList());
        }
    }
}
