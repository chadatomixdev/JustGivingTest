using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.Swagger.Annotations;
using System.Net;

namespace JG.FinTechTest.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GiftAidController : Controller
    {
        #region Properties

        private readonly GiftAidSetup _giftAidOptions;
        private readonly IGiftAidService _giftAidService;
        private readonly IDonationService _donationService;

        #endregion

        #region Constructor

        public GiftAidController(IOptions<GiftAidSetup> giftAidOptions, IGiftAidService giftAidService, IDonationService donationService)
        {
            _giftAidOptions = giftAidOptions.Value;
            _giftAidService = giftAidService;
            _donationService = donationService;

            //Setup GiftAid object based on the saved configuration values
            GiftAidSetup();
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
        public ActionResult GetGiftAid([FromQuery]GiftAidRequest giftAidRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (giftAidRequest is null)
                return BadRequest("Invalid donation");

            var calculatedGiftAidAmount = _giftAidService.Calculate(giftAidRequest.Amount);

            var giftAidResponse = new GiftAidResponse
            {
                DonationAmount = giftAidRequest.Amount,
                GiftAidAmount = calculatedGiftAidAmount
            };

            return Ok(giftAidResponse);
        }

        /// <summary>
        /// Store the donors inforation in the database and return the unique identifier and gift aid
        /// </summary>
        /// <param name="donationRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof(DonationResponse))]
        public ActionResult<DonationResponse> PostDonation([FromQuery]DonationRequest donationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var calculatedGiftAidAmount = _giftAidService.Calculate(donationRequest.Amount);
            var response = _donationService.ReturnDonationResponse(donationRequest, calculatedGiftAidAmount);

            if (response is null)
                return BadRequest();

            return Ok(response);
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