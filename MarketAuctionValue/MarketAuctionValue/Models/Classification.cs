using System.Text.Json.Serialization;

namespace MarketAuctionValue.Models
{
    public class Classification
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("subcategory")]
        public string SubCategory { get; set; }
        [JsonPropertyName("make")]
        public string Make { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }

    }
}
