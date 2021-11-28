using Xunit;
using FakeItEasy;
using System.Threading.Tasks;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToroChallenge.Application.DTOs.Requests;

namespace ToroChallenge.Tests
{
    public class PatrimonioAtivosControllerTest
    {
        [Fact]
        public async Task PostOrder_Retorna_Compra_Sucedida_Do_Usuario()
        {
            // Arrange
            int idUser = 1;
            var order = new OrderRequest { Amount = 1, Symbol = "PETR4" };
            var fakeOrderSuccess = A.Dummy<PositionReponse>();
            var applicationService = A.Fake<IPatrimonioAtivosApplicationService>();
            A.CallTo(() => applicationService.CreateOrUpdatePatrimonioAtivos(idUser, order)).Returns(Task.FromResult(fakeOrderSuccess));
            var controller = new PatrimonioAtivosController(applicationService);
            // Act
            var actionResult = await controller.PostOrder(idUser, order);
            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnUserPosition = result.Value;
            Assert.Equal(fakeOrderSuccess, returnUserPosition);
        }
    }
}
