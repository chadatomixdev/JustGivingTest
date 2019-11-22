using JG.FinTechTest.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace JG.FinTechTest.API.Controllers
{
    [ApiController]
    [Route("api/giftaid")]
    public class GiftAidController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {

            //TODO this is temporary, refacor 
            var giftAid = new GiftAidCalculatorHelper().Calculate(3);

            return Ok("Hello World");
        }
    }
}