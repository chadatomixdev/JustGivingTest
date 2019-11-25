using JG.FinTechTest.Data.Entities;
using JG.FinTechTest.Data.Services;
using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using System;
using System.Linq;

namespace JG.FinTechTest.Shared.Services
{
    public class DonationService : IDonationService
    {
        private readonly RepositoryService _contextService;

        public DonationService(RepositoryService contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// Add a donation to the database
        /// </summary>
        /// <param name="entity"></param>
        public void AddDonation(Donation entity)
        {
            _contextService.Add(entity);
        }

        /// <summary>
        /// Find donation by declaration ID
        /// </summary>
        /// <param name="declarationID"></param>
        /// <returns></returns>
        public Donation GetDonationByDeclarationID(Guid declarationID)
        {
            return _contextService.Find<Donation>(d => d.DeclarationID == declarationID).FirstOrDefault();
        }

        /// <summary>
        /// Build and return the donation response
        /// </summary>
        /// <param name="donationRequest"></param>
        /// <returns></returns>
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

            //TODO Improve with error handling
            AddDonation(donation);

            return new DonationResponse { GiftAidAmount = donation.GiftAidAmount, DeclarationID = donation.DeclarationID };
        }

    }
}