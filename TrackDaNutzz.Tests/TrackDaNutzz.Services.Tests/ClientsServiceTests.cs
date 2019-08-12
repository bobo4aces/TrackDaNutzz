using Microsoft.EntityFrameworkCore;
using System;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.Clients;
using TrackDaNutzz.Services.Dtos.Hands;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class ClientsServiceTests
    {
        //int AddClient(HandInfoDto handInfoDto);
        //string GetClientNameById(int clientId);
        [Fact]
        public void TestAddClient_WithTwoTestClients_ShouldReturnCorrectId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);
            ClientsService clientsService = new ClientsService(context);

            HandInfoDto[] handInfoDtos = GetTestHandInfoDtos();
            int firstClientId = clientsService.AddClient(handInfoDtos[0]);
            int secondClientId = clientsService.AddClient(handInfoDtos[1]);

            int expected = 0;
            int actual = secondClientId;
            Assert.NotEqual(expected, actual);

        }

        [Fact]
        public void TestGetClientNameById_WithTwoTestClients_ShouldReturnCorrectClient()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            ClientsService clientsService = new ClientsService(context);

            HandInfoDto[] handInfoDtos = GetTestHandInfoDtos();
            int firstClientId = clientsService.AddClient(handInfoDtos[0]);
            int secondClientId = clientsService.AddClient(handInfoDtos[1]);

            string clientName = clientsService.GetClientNameById(3);

            string expected = "PokerStars";
            string actual = clientName;
            Assert.Equal(expected, actual);

        }

        private HandInfoDto[] GetTestHandInfoDtos()
        {
            HandInfoDto[] handInfoDto = new HandInfoDto[]
            {
                new HandInfoDto()
                {
                    BigBlind = 0.02m,
                    ClientName = "PokerStars",
                    Currency = "USD",
                    CurrencySymbol = '$',
                    HandNumber = 202717426423,
                    Limit = "No Limit",
                    LocalTime = DateTime.Parse("2019-07-27 07:42:05.0000000"),
                    LocalTimeZone = "ET",
                    SmallBlind = 0.01m,
                    Time = DateTime.Parse("2019-07-27 14:42:05.0000000"),
                    TimeZone = "EET",
                    VariantName = "Hold'em",
                },
                new HandInfoDto()
                {
                    BigBlind = 0.05m,
                    ClientName = "PokerStars",
                    Currency = "USD",
                    CurrencySymbol = '$',
                    HandNumber = 202717479782,
                    Limit = "No Limit",
                    LocalTime = DateTime.Parse("2019-07-27 07:44:42.0000000"),
                    LocalTimeZone = "ET",
                    SmallBlind = 0.02m,
                    Time = DateTime.Parse("2019-07-27 14:44:42.0000000"),
                    TimeZone = "EET",
                    VariantName = "Hold'em",
                },
            };
            return handInfoDto;
        }
    }
}
