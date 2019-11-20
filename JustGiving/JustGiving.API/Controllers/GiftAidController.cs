using Microsoft.AspNetCore.Mvc;

namespace JustGiving.API.Controllers
{
    [ApiController]
    [Route("api/giftaid")]
    public class GiftAidController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Hello World");
        }
    }
}