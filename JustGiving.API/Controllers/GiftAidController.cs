using JG.FinTechTest.Shared.Interfaces;
using JG.FinTechTest.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JG.FinTechTest.API.Controllers
{
    [ApiController]
    [Route("api/giftaid")]
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
        public IActionResult Test()
        {
           return Ok("Hello World");
        }

        [HttpGet]
        public IActionResult giftaid(double amount)
        {
            GiftAidSetup();

            var value = _giftAidService.Calculate(3);

            return Ok(value);

            return Ok();
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