using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using System;

namespace JG.FinTechTest.Shared.Services
{
    public class GiftAidCalculatorService : IGiftAidCalculator
    {

        #region Constructor

        GiftAidSetup _giftAidSetup { get; set; }

        public GiftAidCalculatorService()
        {
           // _giftAidSetup = new GiftAidSetup();
        }

        #endregion

        public void ConfigureGiftAidService(GiftAidSetup setup)
        {
            _giftAidSetup = setup;
        }


        public decimal Calculate(decimal donationAmount)
        {
            return donationAmount * (_giftAidSetup.TaxRate / (100 - _giftAidSetup.TaxRate));
        }


    }
}