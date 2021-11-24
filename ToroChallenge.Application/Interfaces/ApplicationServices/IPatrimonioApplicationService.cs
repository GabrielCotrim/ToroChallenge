using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Responses;

namespace ToroChallenge.Application.Interfaces.ApplicationServices
{
    public interface IPatrimonioApplicationService
    {
        public Task<UserPositionResponse> ObtenhaPatrimonioDoUsuario(int idUser);
    }
}
