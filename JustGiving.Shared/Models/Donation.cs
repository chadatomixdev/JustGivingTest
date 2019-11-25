using System;
using System.ComponentModel.DataAnnotations;

namespace JG.FinTechTest.Shared.Models
{
    public class Donation
    {
        [Key]
        Guid DeclarationID { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public decimal DonationAmount { get; set; }
        public decimal GiftAidAmount { get; set; }
    }
}