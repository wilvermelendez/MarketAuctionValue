using MarketAuctionValue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketAuctionValue.Services
{
    public interface IFileUtils
    {
        Task<Dictionary<int, Equipment>> LoadMarketAuctionFile();
    }
}
