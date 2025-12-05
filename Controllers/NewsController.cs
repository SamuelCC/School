using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services;

namespace School.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly ILogger<NewsController> _logger;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
        {
            _newsService = newsService;
            _logger = logger;
        }

        /// <summary>
        /// Get top MSN news headlines
        /// </summary>
        /// <param name="count">Number of headlines to return (default: 3)</param>
        /// <returns>List of news headlines</returns>
        [HttpGet("msn/headlines")]
        public async Task<ActionResult<List<NewsHeadline>>> GetMsnHeadlines([FromQuery] int count = 3)
        {
            try
            {
                if (count < 1 || count > 10)
                {
                    return BadRequest("Count must be between 1 and 10");
                }

                var headlines = await _newsService.GetTopHeadlinesAsync(count);
                return Ok(headlines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting MSN headlines");
                return StatusCode(500, "An error occurred while fetching news headlines");
            }
        }
    }
}
