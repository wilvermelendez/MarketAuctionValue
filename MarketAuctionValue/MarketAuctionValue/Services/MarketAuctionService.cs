using MarketAuctionValue.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MarketAuctionValue.Services
{
    public class MarketAuctionService : IMarketAuctionService
    {
        private readonly IFileUtils _fileUtils;
        private readonly ILogger<MarketAuctionService> _logger;

        public MarketAuctionService(IFileUtils fileUtils, ILogger<MarketAuctionService> logger)
        {
            _fileUtils = fileUtils;
            _logger = logger;
        }
        public async Task<ResponseData> GetCalculatedValuesByModelAndYear(int modelId, int year)
        {
            var response = new ResponseData()
            {
                Success = false
            };
            try
            {
                var result = await _fileUtils.LoadMarketAuctionFile();
                if (result.ContainsKey(modelId) && result[modelId].Schedule.Years.ContainsKey(year))
                {
                    var ratioValues = new RatioValues()
                    {
                        MarketValue = result[modelId].SaleDetail.Cost * (decimal)result[modelId].Schedule.Years[year].MarketRatio,
                        AuctionValue = result[modelId].SaleDetail.Cost * (decimal)result[modelId].Schedule.Years[year].AuctionRatio

                    };
                    response.Success = true;
                    response.Data = ratioValues;
                    return response;
                }

                response.Message = !result.ContainsKey(modelId)
                    ? $"Unfortunately the model equipment id {modelId} was not found in our database."
                    : $"Unfortunately the model equipment id {modelId} and year {year} was not found in our database.";


                _logger.LogInformation(response.Message);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                Console.WriteLine(e);
                throw;
            }
            return response;

        }
    }
}
