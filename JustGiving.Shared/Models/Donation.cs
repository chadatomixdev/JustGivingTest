using System;
using System.Collections.Generic;
using System.Text;

namespace JG.FinTechTest.Shared.Models
{
    public class Donation
    {
        Guid DeclarationID { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public decimal DonationAmount { get; set; }
        public decimal GiftAidAmount { get; set; }
    }
}