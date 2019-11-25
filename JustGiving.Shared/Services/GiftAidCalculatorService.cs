using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;

namespace JG.FinTechTest.Shared.Services
{
    public class GiftAidCalculatorService : IGiftAidService
    {

        #region Constructor

        GiftAidSetup GiftAidSetup { get; set; }

        #endregion

        public void ConfigureGiftAidService(GiftAidSetup setup)
        {
            GiftAidSetup = setup;
        }

        public decimal Calculate(decimal donationAmount)
        {
            return donationAmount * (GiftAidSetup.TaxRate / (100 - GiftAidSetup.TaxRate));
        }
    }
}