using Data.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Search;
using Services.Trending;

namespace AmazonProductSearchAPI.Controllers.Search
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ITrendingService _trendingService;
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;

        public SearchController(ITrendingService trendingService, ISearchService searchService, ILogger<SearchController> logger)
        {
            _trendingService = trendingService;
            _searchService = searchService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("suggestion")]
        public ActionResult<SuggestionResponse> GetSuggestions([FromQuery] SuggestionRequest req)
        {
            var res = _searchService.GetSuggestions(req);

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("search")]
        public ActionResult<SearchResponse> SearchAmazonProduct([FromBody] SearchRequest req)
        {
            // Tracking search trending
            _trendingService.TrackSearch(req.SearchText);

            var res = _searchService.SearchAmazonProduct(req);

            return Ok(res);
        }
    }
}
