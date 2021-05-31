using System.Text.Json.Serialization;

namespace MarketAuctionValue.Models
{
    public class SaleDetail
    {
        [JsonPropertyName("cost")]
        public decimal Cost { get; set; }
        [JsonPropertyName("retailSaleCount")]
        public int RetailSaleCount { get; set; }
        [JsonPropertyName("auctionSaleCount")]
        public int AuctionSaleCount { get; set; }
    }
}
