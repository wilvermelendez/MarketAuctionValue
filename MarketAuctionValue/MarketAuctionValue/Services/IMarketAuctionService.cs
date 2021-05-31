using MarketAuctionValue.DTO;
using System.Threading.Tasks;

namespace MarketAuctionValue.Services
{
    public interface IMarketAuctionService
    {
        Task<ResponseData> GetCalculatedValuesByModelAndYear(int id, int year);
    }
}