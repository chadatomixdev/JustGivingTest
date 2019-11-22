using System;
using JG.FinTechTest.API.Helpers;
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

        public GiftAidController(IOptions<GiftAidSetup> giftAidOptions)
        {
            _giftAidOptions = giftAidOptions.Value;
        }

        [HttpGet]
        public IActionResult Test()
        {


            //TODO this is temporary, refacor 
            var giftAid = new GiftAidCalculatorHelper().Calculate(3);

            GiftAidSetup();


            return Ok("Hello World");
        }

        private void GiftAidSetup()
        {
            //GiftAid is setup to be configurable using the appsettings file. 
            //Retrieve the GifAid setup object

            var tr =_giftAidOptions.TaxRate;
            
        }
    }
}