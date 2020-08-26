using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Leviathanbadger.FeedScraper.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/about")]
    public class AboutController : ControllerBase
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(
            ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<AboutInfo> Get()
        {
            return new AboutInfo();
        }
    }
}
