using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using ToroChallenge.Application.DTOs.Responses;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Api.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace ToroChallenge.Tests
{
    public class AtivoControllerTest
    {
        [Fact]
        public async Task GetPatrimonio_Retorna_A_Quantidade_Correta_De_Trends()
        {
            // Arrange
            int count = 5;
            var fakeTrends = A.CollectionOfDummy<TrendResponse>(count).ToList();
            var applicationService = A.Fake<IAtivoApplicationService>();
            A.CallTo(() => applicationService.GetTopTrends()).Returns(Task.FromResult(fakeTrends));
            var controller = new AtivoController(applicationService);
            // Act
            var actionResult = await controller.GetTopTrends();
            // Assert
            var result = actionResult.Result as OkObjectResult;
            var returnTrends = result.Value as List<TrendResponse>;
            Assert.Equal(count, returnTrends.Count);
        }
    }
}
