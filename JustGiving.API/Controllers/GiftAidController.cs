using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JG.FinTechTest.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GiftAidController : Controller
    {
        #region Properties

        private readonly GiftAidSetup _giftAidOptions;
        private readonly IGiftAidCalculator _giftAidService;

        #endregion

        #region Constructor

        public GiftAidController(IOptions<GiftAidSetup> giftAidOptions, IGiftAidCalculator giftAidService)
        {
            _giftAidOptions = giftAidOptions.Value;
            _giftAidService = giftAidService;
        }

        #endregion

        /// <summary>
        /// Get the amount of gift aid reclaimable for donation amount
        /// </summary>
        /// <param name="giftAidRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("giftaid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetGiftAid([FromQuery]GiftAidRequest giftAidRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (giftAidRequest is null)
                return BadRequest("Invalid donation");

            //Setup GiftAid object based on saved configuration and calculate the GiftAid value
            GiftAidSetup();

            var calculatedGiftAidAmount = _giftAidService.Calculate(giftAidRequest.Amount);

            var giftAidResponse = new GiftAidResponse
            {
                DonationAmount = giftAidRequest.Amount,
                GiftAidAmount = calculatedGiftAidAmount
            };

            return Ok(giftAidResponse);
        }

        [HttpGet]
        [Route("donate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostDonation([FromQuery]DonationRequest donationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        #region Private Methods

        /// <summary>
        /// Configure the GiftAid setup object with the configurable GiftAid settings from appsettings.json file
        /// </summary>
        private void GiftAidSetup()
        {
            _giftAidService.ConfigureGiftAidService(_giftAidOptions);
        }

        #endregion
    }
}