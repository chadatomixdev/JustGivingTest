using Microsoft.AspNetCore.Mvc;

namespace JG.FinTechTest.API.Controllers
{
    [Route("api/")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Test API method to ensure the API is running
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("test")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}