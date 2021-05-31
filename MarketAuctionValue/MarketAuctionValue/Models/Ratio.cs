using System.Text.Json.Serialization;

namespace MarketAuctionValue.Models
{
    public class Ratio
    {
        [JsonPropertyName("marketRatio")]
        public double MarketRatio { get; set; }
        [JsonPropertyName("auctionRatio")]
        public double AuctionRatio { get; set; }
    }
}
