using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using JG.FinTechTest.Shared.Services;
using JG.FinTechTest.UnitTests.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidCalculatorUnitTests : IClassFixture<Setup>
    {
        private readonly IGiftAidService _giftAidService;
        private readonly IOptions<GiftAidSetup> _giftAidOptions;
        readonly ServiceProvider _serviceProvider;

        public GiftAidCalculatorUnitTests(Setup setup)
        {
            _serviceProvider = setup.ServiceProvider;
            _giftAidOptions = _serviceProvider.GetRequiredService<IOptions<GiftAidSetup>>();
            _giftAidService = new GiftAidCalculatorService();
            _giftAidService.ConfigureGiftAidService(_giftAidOptions.Value);
        }

        [Theory]
        [InlineData(150, 37.5)]
        [InlineData(300, 75)]
        [InlineData(2000, 500)]
        public void CalculateGiftAidReturnCorrectGiftAid(decimal donationAmount, decimal expectedValue)
        {
            // Act
            var result = _giftAidService.Calculate(donationAmount);

            // Assert
            Assert.Equal(result, expectedValue);
        }
    }
}