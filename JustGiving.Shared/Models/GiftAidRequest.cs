using System.ComponentModel.DataAnnotations;

namespace JG.FinTechTest.Shared.Models
{
    public class GiftAidRequest
    {
        [Required]
        [Range(2.00, 100000.00)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
    }
}