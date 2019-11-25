using JG.FinTechTest.Data.Entities;
using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using System;
using System.Linq;

namespace JG.FinTechTest.UnitTests.Fakes
{
    public class DonationServiceFake : BaseFake, IDonationService
    {
        public void AddDonation(Donation entity)
        {
        }

        public Donation GetDonationByDeclarationID(Guid declarationID)
        {
            return Donations.Where(d => d.DeclarationID == declarationID).FirstOrDefault();
        }

        public DonationResponse ReturnDonationResponse(DonationRequest donationRequest, decimal giftAidamount)
        {
            var donation = new Donation
            {
                DeclarationID = Guid.NewGuid(),
                DonationAmount = donationRequest.Amount,
                Name = donationRequest.Name,
                PostCode = donationRequest.PostCode,
                GiftAidAmount = giftAidamount
            };

            return new DonationResponse { GiftAidAmount = donation.GiftAidAmount, DeclarationID = donation.DeclarationID };
        }
    }
}