using MarketAuctionValue.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketAuctionValue.Services
{
    public class FileUtils : IFileUtils
    {
        public async Task<Dictionary<int, Equipment>> LoadMarketAuctionFile()
        {
            const string fileName = "Database.json";
            var jsonString = File.OpenRead(fileName);
            return await JsonSerializer.DeserializeAsync<Dictionary<int, Equipment>>(jsonString);
        }
    }
}