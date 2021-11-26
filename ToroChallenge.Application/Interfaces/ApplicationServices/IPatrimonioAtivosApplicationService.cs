using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Requests;
using ToroChallenge.Application.DTOs.Responses;

namespace ToroChallenge.Application.Interfaces.ApplicationServices
{
    public interface IPatrimonioAtivosApplicationService
    {
        public Task<PositionReponse> CreateOrUpdatePatrimonioAtivos(int idUser, OrderRequest order);
    }
}
