using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JG.FinTechTest.UnitTests.Fakes
{
    public class GiftAidServiceFake : IGiftAidService
    {
        public decimal Calculate(decimal donationAmount)
        {
            throw new NotImplementedException();
        }

        public void ConfigureGiftAidService(GiftAidSetup setup)
        {
            throw new NotImplementedException();
        }
    }
}
