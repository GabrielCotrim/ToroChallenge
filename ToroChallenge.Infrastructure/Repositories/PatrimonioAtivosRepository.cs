using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.Interfaces.Repositories;
using ToroChallenge.Application.Utils.Exceptions;
using ToroChallenge.Domain.Entities;
using ToroChallenge.Infrastructure.Data;

namespace ToroChallenge.Infrastructure.Repositories
{
    public class PatrimonioAtivosRepository : IPatrimonioAtivosRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<PatrimonioAtivos> _dbSet;

        public PatrimonioAtivosRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<PatrimonioAtivos>();
        }

        public Task<PatrimonioAtivos> CreatePatrimonioAtivos(PatrimonioAtivos patrimonioAtivos)
        {
            _dbSet.Add(patrimonioAtivos);
            _context.SaveChanges();
            return Task.FromResult(patrimonioAtivos);
        }

        public Task<PatrimonioAtivos> GetPatrimonioAtivos(PatrimonioAtivos patrimonioAtivos)
        {
            return _dbSet.FirstOrDefaultAsync(pa => pa.PatrimonioId == patrimonioAtivos.PatrimonioId && pa.AtivoId == patrimonioAtivos.AtivoId);
        }

        public Task<List<PatrimonioAtivos>> GetTopTrends(int quantidade)
        {
            var patrimonioAtivos = _dbSet
                .Include(pa => pa.Ativo)
                .OrderByDescending(pa => pa.QuantidadeAtivos)
                .Take(quantidade)?.ToList();

            return Task.FromResult(patrimonioAtivos);
        }

        public Task<PatrimonioAtivos> UpdatePatrimonioAtivos(PatrimonioAtivos patrimonioAtivos)
        {
            _context.Entry(patrimonioAtivos.Ativo).State = EntityState.Detached;
            _context.Entry(patrimonioAtivos.Patrimonio).State = EntityState.Detached;
            _dbSet.Update(patrimonioAtivos);
            _context.SaveChanges();
            return Task.FromResult(patrimonioAtivos);
        }
    }
}
