using System.ComponentModel.DataAnnotations;

namespace JG.FinTechTest.Shared.Models
{
    public class GiftAidResponse
    {
        [Required]
        public decimal DonationAmount { get; set; }

        [Required]
        public decimal GiftAidAmount { get; set; }
    }
}