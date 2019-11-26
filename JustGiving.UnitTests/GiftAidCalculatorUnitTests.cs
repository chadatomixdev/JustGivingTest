using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Services;
using JG.FinTechTest.UnitTests.Config;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidCalculatorUnitTests : IClassFixture<Setup>
    {
        private readonly IGiftAidService _giftAidService;

        public GiftAidCalculatorUnitTests()
        {
            _giftAidService = new GiftAidCalculatorService();
        }

        [Theory]
        [InlineData(150, 37.5)]
        [InlineData(300, 75)]
        [InlineData(2000, 500)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(decimal donationAmount, decimal expectedValue)
        {
            // Act
            expectedValue = _giftAidService.Calculate(donationAmount);

            // Assert
            Assert.Equal(donationAmount, expectedValue);
        }
    }
}