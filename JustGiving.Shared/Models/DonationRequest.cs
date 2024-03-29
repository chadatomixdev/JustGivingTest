﻿using System.ComponentModel.DataAnnotations;

namespace JG.FinTechTest.Shared.Models
{
    public class DonationRequest : GiftAidRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}