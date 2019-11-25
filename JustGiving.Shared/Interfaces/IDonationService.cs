using JG.FinTechTest.Data.Entities;
using JG.FinTechTest.Shared.Models;
using System;

namespace JG.FinTechTest.Shared.Interfaces
{
    public interface IDonationService
    {
        void AddDonation(Donation entity);

        DonationResponse ReturnDonationResponse(DonationRequest donationRequest, decimal giftAidamount);

        Donation GetDonationByDeclarationID(Guid declarationID);
    }
}