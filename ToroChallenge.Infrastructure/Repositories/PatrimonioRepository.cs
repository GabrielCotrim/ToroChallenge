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
        public PatrimonioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Patrimonio> ObtenhaPatrimonioDoUsuario(int idUser)
        {
            var patrimonio = _context.Patrimonios.FirstOrDefault(p => p.UsuarioId == idUser);
            if (patrimonio == null) throw new NotFoundException();
            return Task.FromResult(patrimonio);
        }
    }
}
