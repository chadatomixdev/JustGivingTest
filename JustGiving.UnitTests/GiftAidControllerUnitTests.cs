using JG.FinTechTest.API.Controllers;
using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using JG.FinTechTest.Shared.Services;
using JG.FinTechTest.UnitTests.Config;
using JG.FinTechTest.UnitTests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidControllerUnitTests : IClassFixture<Setup>
    {
        #region Properties
     
        private readonly IOptions<GiftAidSetup> _giftAidOptions;
        private readonly IGiftAidService _giftAidService;
        private readonly IDonationService _donationService;
        private readonly GiftAidController _giftAidController;
        readonly ServiceProvider _serviceProvider;

        #endregion

        public GiftAidControllerUnitTests(Setup setup)
        {
            _serviceProvider = setup.ServiceProvider;
            _giftAidService = new GiftAidCalculatorService();
            _donationService = new DonationServiceFake();
            _giftAidOptions = _serviceProvider.GetRequiredService<IOptions<GiftAidSetup>>();
            _giftAidController = new GiftAidController(_giftAidOptions, _giftAidService, _donationService);
        }

        [Fact]
        public void GetGiftAidShouldReturnOkResult()
        {
            // Arrange
            var request = new GiftAidRequest { Amount = 300 };

            // Act
            var createdResponse = _giftAidController.GetGiftAid(request);

            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public void GetGiftAidValidRequestReturnsValidResponse()
        {
            // Arrange
            var request = new GiftAidRequest { Amount = 500 };

            // Act
            var createdResponse = _giftAidController.GetGiftAid(request) as OkObjectResult;

            // Assert
            Assert.IsType<GiftAidResponse>(createdResponse.Value);
        }

        //[Fact]
        //public void GetGiftAidInvalidAmounttReturnsBadRequest()
        //{
        //    // Arrange
        //    var request = new GiftAidRequest { Amount = 1 };

        //    // Act
        //    var createdResponse = _giftAidController.GetGiftAid(request);

        //    var a = _giftAidController.TryValidateModel(request);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(request);
        //}


    }
}