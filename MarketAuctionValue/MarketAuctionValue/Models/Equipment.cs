using System.Text.Json.Serialization;

namespace MarketAuctionValue.Models
{
    public class Equipment
    {
        [JsonPropertyName("schedule")]
        public Schedule Schedule { get; set; }
        [JsonPropertyName("saleDetails")]
        public SaleDetail SaleDetail { get; set; }
        [JsonPropertyName("classification")]
        public Classification Classification { get; set; }
    }
}
