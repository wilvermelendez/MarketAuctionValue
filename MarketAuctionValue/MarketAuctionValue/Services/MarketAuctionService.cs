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
        public async Task<ResponseData> GetCalculatedValuesByModelAndYear(int id, int year)
        {
            var response = new ResponseData()
            {
                Success = false
            };
            try
            {
                var result = await _fileUtils.LoadMarketAuctionFile();
                if (result.ContainsKey(id) && result[id].Schedule.Years.ContainsKey(year))
                {
                    var ratioValues = new RatioValues()
                    {
                        MarketValue = result[id].SaleDetail.Cost * (decimal)result[id].Schedule.Years[year].MarketRatio,
                        AuctionValue = result[id].SaleDetail.Cost * (decimal)result[id].Schedule.Years[year].AuctionRatio

                    };
                    response.Success = true;
                    response.Data = ratioValues;
                    return response;
                }

                response.Message = !result.ContainsKey(id)
                    ? $"Unfortunately the model equipment id {id} was not found in our database."
                    : $"Unfortunately the model equipment id {id} and year {year} was not found in our database.";


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
