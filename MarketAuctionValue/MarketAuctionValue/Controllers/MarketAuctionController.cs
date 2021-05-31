using MarketAuctionValue.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;


namespace MarketAuctionValue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MarketAuctionController : ControllerBase
    {

        private readonly IMarketAuctionService _marketAuctionService;

        public MarketAuctionController(IMarketAuctionService marketAuctionService)
        {
            _marketAuctionService = marketAuctionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCalculatedValuesByModelAndYear(int modelId, int year)
        {
            var response = await _marketAuctionService.GetCalculatedValuesByModelAndYear(modelId, year);
            if (response.Success)
            {
                return Ok(JsonSerializer.Serialize(response));
            }
            return NotFound(response.Message);
        }
    }
}
