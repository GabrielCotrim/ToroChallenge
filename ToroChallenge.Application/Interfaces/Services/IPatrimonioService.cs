using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.Interfaces.Services
{
    public interface IPatrimonioService
    {
        public Task<Patrimonio> ObtenhaPatrimonioDoUsuario(int idUser);
    }
}
