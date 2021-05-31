using MarketAuctionValue.Services;
using Microsoft.Extensions.DependencyInjection;


namespace MarketAuctionValue.Test
{


    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFileUtils, FileUtils>();
            services.AddScoped<IMarketAuctionService, MarketAuctionService>();
        }
    }

}
