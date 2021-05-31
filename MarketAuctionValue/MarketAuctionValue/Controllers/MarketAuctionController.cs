using MarketAuctionValue.DTO;
using MarketAuctionValue.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;


namespace MarketAuctionValue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MarketAuctionController : ControllerBase
    {
        private readonly IFileUtils _fileUtils;
        private readonly ILogger<MarketAuctionController> _logger;
        public MarketAuctionController(ILogger<MarketAuctionController> logger, IFileUtils fileUtils)
        {
            _fileUtils = fileUtils;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> GetCalculatedValuesByModelAndYear(int modelId, int year)
        {
            var result = await _fileUtils.LoadMarketAuctionFile();

            if (result.ContainsKey(modelId) && result[modelId].Schedule.Years.ContainsKey(year))
            {
                var ratioValues = new RatioValues()
                {
                    MarketValue = result[modelId].SaleDetail.Cost * (decimal)result[modelId].Schedule.Years[year].MarketRatio,
                    AuctionValue = result[modelId].SaleDetail.Cost * (decimal)result[modelId].Schedule.Years[year].AuctionRatio

                };
                return Ok(JsonSerializer.Serialize(ratioValues));
            }

            return NotFound($"Unfortunately the model equipment id {modelId} and year {year} was not found in our database.");
        }
    }
}
