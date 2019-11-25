using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Services;

namespace JG.FinTechTest.UnitTests
{
    public class GiftAidCalculatorUnitTests
    {
        private readonly IGiftAidService _giftAidService;

        public GiftAidCalculatorUnitTests()
        {
            _giftAidService = new GiftAidCalculatorService();
        }



    }
}