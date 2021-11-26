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
    public sealed class PatrimonioRepository : IPatrimonioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Patrimonio> _dbSet;
        public PatrimonioRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Patrimonio>();
        }

        public Task<Patrimonio> ObtenhaPatrimonioDoUsuario(int idUser)
        {
            var patrimonio = _dbSet.Include(p => p.PatrimonioAtivos)
                                .ThenInclude(pa => pa.Ativo)
                                .FirstOrDefault(p => p.UsuarioId == idUser);
            if (patrimonio == null) throw new NotFoundException();
            return Task.FromResult(patrimonio);
        }
    }
}
