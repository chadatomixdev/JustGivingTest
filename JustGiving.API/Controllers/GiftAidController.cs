using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JG.FinTechTest.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GiftAidController : Controller
    {
        private readonly GiftAidSetup _giftAidOptions;
        private readonly IGiftAidCalculator _giftAidService;

        public GiftAidController(IOptions<GiftAidSetup> giftAidOptions, IGiftAidCalculator giftAidService)
        {
            _giftAidOptions = giftAidOptions.Value;
            _giftAidService = giftAidService;
        }

        [HttpGet]
        [Route("giftaid")]
        public IActionResult GetGiftAid(decimal amount)
        {

            //[FromBody]GiftAidRequest giftAid

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GiftAidSetup();

            var value = _giftAidService.Calculate(amount);

            return Ok(value);
        }

        /// <summary>
        /// Configure the GiftAid setup object with the configurable GiftAid settings
        /// </summary>
        private void GiftAidSetup()
        {
            _giftAidService.ConfigureGiftAidService(_giftAidOptions);
        }
    }
}