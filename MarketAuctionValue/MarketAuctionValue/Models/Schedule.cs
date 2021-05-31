using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarketAuctionValue.Models
{
    public class Schedule
    {
        [JsonPropertyName("years")]
        public Dictionary<int, Ratio> Years { get; set; }
        [JsonPropertyName("defaultMarketRatio")]
        public double DefaultMarketRatio { get; set; }
        [JsonPropertyName("defaultAuctionRatio")]
        public double DefaultAuctionRatio { get; set; }
    }
}
