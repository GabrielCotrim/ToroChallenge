using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.Interfaces.Repositories
{
    public interface IPatrimonioRepository
    {
        public Task<Patrimonio> ObtenhaPatrimonioDoUsuario(int idUser);
    }
}
