using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using System;

namespace JG.FinTechTest.Shared.Services
{
    public class IGiftAidCalculatorService : IGiftAidCalculator
    {

        #region Constructor

        GiftAidSetup _giftAidSetup { get; set; }

        public IGiftAidCalculatorService()
        {
            _giftAidSetup = new GiftAidSetup();
        }

        #endregion

        public void ConfigureGiftAidService(decimal taxRate, decimal minDonation, decimal maxDonation)
        {
            throw new NotImplementedException();
        }

        public decimal Calculate(decimal donationAmount)
        {
            throw new NotImplementedException();
        }
    }
}