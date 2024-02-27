using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Trending;

namespace AmazonProductSearchAPI.Controllers.Trending
{
    [Route("api/trending")]
    [ApiController]
    public class TrendingController : Controller
    {
        private readonly ITrendingService _trendingService;
        private readonly ILogger<TrendingController> _logger;

        public TrendingController(ITrendingService trendingService, ILogger<TrendingController> logger)
        {
            _trendingService = trendingService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetTrendingData()
        {
            var trendingData = _trendingService.GetTrendingSuggestionsWithCounts();
            return Ok(trendingData);
        }
    }
}
