using JG.FinTechTest.API.Controllers;
using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using JG.FinTechTest.Shared.Services;
using JG.FinTechTest.UnitTests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidControllerUnitTests
    {
        private readonly IGiftAidService _giftAidService;
        private readonly IDonationService _donationService;
        private readonly GiftAidController _giftAidController;

        public GiftAidControllerUnitTests()
        {
            _giftAidService = new GiftAidCalculatorService();
            _donationService = new DonationServiceFake();
            //_giftAidController = new GiftAidController()
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
    }
}