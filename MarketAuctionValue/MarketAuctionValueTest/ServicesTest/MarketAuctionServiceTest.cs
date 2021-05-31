using MarketAuctionValue.Services;
using System.Threading.Tasks;
using Xunit;

namespace MarketAuctionValueTest.ServicesTest
{
    public class MarketAuctionServiceTest
    {
        private readonly IMarketAuctionService _marketAuctionService;

        public MarketAuctionServiceTest(IMarketAuctionService marketAuctionService)
        {
            _marketAuctionService = marketAuctionService;
        }
        [Fact]
        public async Task GetCalculatedValuesByModelAndYear_WhenEquipmentNotExists_ReturnNotFound()
        {
            //Arrange
            var id = 2021;
            var year = 2011;
            //Act
            var result = await _marketAuctionService.GetCalculatedValuesByModelAndYear(id, year);
            //Assert
            Assert.False(result.Success);
            Assert.NotEmpty(result.Message);
        }

        [Fact]
        public async Task GetCalculatedValuesByModelAndYear_WhenEquipmentAndYearNotExists_ReturnNotFound()
        {
            //Arrange
            var id = 2021;
            var year = 2011;
            //Act
            var result = await _marketAuctionService.GetCalculatedValuesByModelAndYear(id, year);
            //Assert
            Assert.False(result.Success);
            Assert.NotEmpty(result.Message);
        }
        [Theory]
        [InlineData(67352, 2004)]
        [InlineData(87964, 2011)]
        public async Task GetCalculatedValuesByModelAndYear_WhenEquipmentExistAndYearNotExists_ReturnNotFound(int id, int year)
        {

            //Act
            var result = await _marketAuctionService.GetCalculatedValuesByModelAndYear(id, year);
            //Assert
            Assert.False(result.Success);
            Assert.NotEmpty(result.Message);
        }

        [Theory]
        [InlineData(67352, 2006)]
        [InlineData(67352, 2011)]
        public async Task GetCalculatedValuesByModelAndYear_WhenEquipmentAndYearExists_ReturnValues(int id, int year)
        {

            //Act
            var result = await _marketAuctionService.GetCalculatedValuesByModelAndYear(id, year);
            //Assert
            Assert.True(result.Success);
            Assert.True(result.Data.AuctionValue > 0);
            Assert.True(result.Data.MarketValue > 0);
            Assert.Null(result.Message);
        }
    }
}
