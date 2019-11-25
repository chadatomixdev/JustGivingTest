using JG.FinTechTest.Data.Entities;
using JG.FinTechTest.Shared.Models;

namespace JG.FinTechTest.Shared.Interfaces
{
    public interface IDonationService
    {
        void AddDonation(Donation entity);

        DonationResponse ReturnDonationResponse(DonationRequest donationRequest, decimal giftAidamount);
    }
}