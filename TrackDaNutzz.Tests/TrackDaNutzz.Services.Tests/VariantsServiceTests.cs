using Microsoft.EntityFrameworkCore;
using System;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Variants;
using TrackDaNutzz.Services.Variant;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class VariantsServiceTests
    {
        //int AddVariant(HandInfoDto handInfoDto);
        //VariantDto GetVariantById(int variantId);

        [Fact]
        public void TestAddVariant_WithOneHandInfoDto_ShouldReturnCorrectId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            VariantsService variantService = new VariantsService(context);

            HandInfoDto handInfoDto = this.GetTestHandInfoDto();
            int variantId = variantService.AddVariant(handInfoDto);

            int expected = 1;
            int actual = variantId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetVariantById_WithOneVariantId_ShouldReturnCorrectVariant()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            VariantsService variantService = new VariantsService(context);

            HandInfoDto handInfoDto = this.GetTestHandInfoDto();
            int variantId = variantService.AddVariant(handInfoDto);

            VariantDto variantDto = variantService.GetVariantById(variantId);
            int expected = 3;
            int actual = variantDto.Id;

            Assert.Equal(expected, actual);
        }

        private HandInfoDto GetTestHandInfoDto()
        {
            HandInfoDto handInfoDto = new HandInfoDto()
            {
                BigBlind = 0.02m,
                ClientName = "PokerStars",
                Currency = "USD",
                CurrencySymbol = '$',
                HandNumber = 202717426423,
                Limit = "No Limit",
                LocalTime = DateTime.Now,
                LocalTimeZone = "ET",
                SmallBlind = 0.01m,
                Time = DateTime.Now,
                TimeZone = "EET",
                VariantName = "Hold'em",
            };
            return handInfoDto;
        }
    }
}
