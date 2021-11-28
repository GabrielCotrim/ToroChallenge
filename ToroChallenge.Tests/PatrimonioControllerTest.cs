using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ToroChallenge.Api;
using Xunit;
using FakeItEasy;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ToroChallenge.Tests
{
    public class PatrimonioControllerTest
    {
        [Fact]
        public async Task GetPatrimonio_Retorna_O_Patrimonio_Do_Usuario()
        {
            // Arrange
            int idUser = 1;
            var fakeUserPosition = A.Dummy<UserPositionResponse>();
            var applicationService = A.Fake<IPatrimonioApplicationService>();
            A.CallTo(() => applicationService.ObtenhaPatrimonioDoUsuario(idUser)).Returns(Task.FromResult(fakeUserPosition));
            var controller = new PatrimonioController(applicationService);
            // Act
            var actionResult = await controller.GetUserPosition(idUser);
            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnUserPosition = result.Value;
            Assert.Equal(fakeUserPosition, returnUserPosition);
        }
    }
}
