using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Stakes;
using TrackDaNutzz.Services.Stakes;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class StakesServiceTests
    {
        //int AddStake(HandInfoDto handInfoDto);
        //IQueryable<StakeDto> GetStakeByStakeId(params int[] stakeIds);

        [Fact]
        public void TestAddStake_WithOneHandInfoDto_ShouldReturnCorrectId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);

            HandInfoDto handInfoDto = this.GetTestHandInfoDto();
            int stakeId = stakesService.AddStake(handInfoDto);

            int expected = 3;
            int actual = stakeId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetStakeByStakeId_WithOneStakeId_ShouldReturnCorrectStake()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);

            HandInfoDto handInfoDto = this.GetTestHandInfoDto();
            int stakeId = stakesService.AddStake(handInfoDto);
            StakeDto stakeDto = stakesService.GetStakeByStakeId(stakeId).FirstOrDefault();
            int expected = 1;
            int actual = stakeDto.Id;

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
