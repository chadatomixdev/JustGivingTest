using JG.FinTechTest.Data.Entities;
using System;
using System.Collections.Generic;

namespace JG.FinTechTest.UnitTests.Fakes
{
    public class BaseFake
    {
        #region Properties 

        public List<Donation> Donations = new List<Donation>();

        #endregion

        public BaseFake()
        {
            GenerateFakeDonations();
        }

        private void GenerateFakeDonations()
        {
            var _donation1 = new Donation { DeclarationID = Guid.Parse("1D620903-D485-4421-958F-8265C0B41844"), DonationAmount = 300, GiftAidAmount = 75, Name = "Bill", PostCode = "GA1" };
            var _donation2 = new Donation { DeclarationID = Guid.Parse("311BFB23-11F9-44DA-B3F9-EF53DA3E6753"), DonationAmount = 2000, GiftAidAmount = 500, Name = "Susan", PostCode = "RW2" };
            var _donation3 = new Donation { DeclarationID = Guid.Parse("5D161A26-91A4-4784-8DEF-FAF0A3F9E8B7"), DonationAmount = 150, GiftAidAmount = 37.5m, Name = "Tim", PostCode = "RW2" };

            Donations.Add(_donation1);
            Donations.Add(_donation2);
            Donations.Add(_donation3);
        }
    }
}