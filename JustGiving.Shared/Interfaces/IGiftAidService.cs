using JG.FinTechTest.Shared.Models;

namespace JG.FinTechTest.Shared.Interfaces
{
    public interface IGiftAidService
    {
        decimal Calculate(decimal donationAmount);
        void ConfigureGiftAidService(GiftAidSetup setup);
    }
}