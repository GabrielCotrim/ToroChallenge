using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Domain.Models;

namespace ToroChallenge.Application.Interfaces.Services
{
    public interface IPatrimonioService
    {
        public Task<UserPositionModel> ObtenhaPatrimonioDoUsuario(int idUser);
    }
}
