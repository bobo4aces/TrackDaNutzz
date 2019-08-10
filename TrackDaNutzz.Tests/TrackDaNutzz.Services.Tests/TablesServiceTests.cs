using Microsoft.EntityFrameworkCore;
using TrackDaNutzz.Services.BettingActions;
using TrackDaNutzz.Services.Boards;
using TrackDaNutzz.Services.Clients;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.HandPlayers;
using TrackDaNutzz.Services.Hands;
using TrackDaNutzz.Services.Import;
using TrackDaNutzz.Services.Players;
using TrackDaNutzz.Services.Stakes;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Tables;
using TrackDaNutzz.Services.Users;
using TrackDaNutzz.Services.Variant;
using System;
using TrackDaNutzz.Data;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Data.Models;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class TablesServiceTests
    {
        //int AddTable(ImportTableDto tableDto, int clientId, int stakeId, int variantId);
        //bool IsExist(int tableId);
        //IQueryable<int> GetTablesIdsByStakeId(params int[] stakeIds);
        //IQueryable<int> GetStakeIdsByTableId(params int[] tableIds);
        //TableDto GetTableById(long tableId);
        //IEnumerable<TableDto> GetTableById(params int[] tableIds);
        [Fact]
        public void TestAddTable_WithOneTable_ShouldReturnTableId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);

            ImportTableDto importTable = this.GetTestImportTable();
            int clientId = 1;
            int stakeId = 1;
            int variantId = 1;

            int tableId = tablesService.AddTable(importTable, clientId, stakeId, variantId);

            int expected = 7;
            int actual = tableId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIsExist_WithOneTableId_ShouldReturnTrue()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);

            ImportTableDto importTable = this.GetTestImportTable();
            int clientId = 1;
            int stakeId = 1;
            int variantId = 1;

            int tableId = tablesService.AddTable(importTable, clientId, stakeId, variantId);
            bool isExist = tablesService.IsExist(tableId);
            bool expected = true;
            bool actual = isExist;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetTablesIdsByStakeId_WithOneStakeId_ShouldReturnCorrectTableId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);

            ImportTableDto importTable = this.GetTestImportTable();
            int clientId = 1;
            int stakeId = 1;
            int variantId = 1;

            int tableId = tablesService.AddTable(importTable, clientId, stakeId, variantId);
            int stakeTableId = tablesService.GetTablesIdsByStakeId(stakeId).FirstOrDefault();
            int expected = 8;
            int actual = stakeTableId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetStakeIdsByTableId_WithOneTableId_ShouldReturnCorrectStakeId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);

            ImportTableDto importTable = this.GetTestImportTable();
            int clientId = 1;
            int stakeId = 1;
            int variantId = 1;

            int tableId = tablesService.AddTable(importTable, clientId, stakeId, variantId);
            int tableStakeId = tablesService.GetStakeIdsByTableId(tableId).FirstOrDefault();
            int expected = 1;
            int actual = tableStakeId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetTableById_WithOneTableId_ShouldReturnCorrectTable()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);

            ImportTableDto importTable = this.GetTestImportTable();
            int clientId = 1;
            int stakeId = 1;
            int variantId = 1;

            ImportTableDto tableDto = this.GetTestImportTable();
            int tableId = tablesService.AddTable(tableDto, clientId, stakeId, variantId);
            List<TableDto> tables = tablesService.GetTableById(tableId).ToList();
            int expected = 1;
            int actual = tables.Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetTableById_WithThreeTableIds_ShouldReturnCorrectCount()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            StakesService stakesService = new StakesService(context);
            VariantsService variantsService = new VariantsService(context);
            ClientsService clientsService = new ClientsService(context);
            TablesService tablesService = new TablesService(context, stakesService, variantsService, clientsService);

            ImportTableDto[] importTable = this.GetTestImportTables();
            int clientId = 1;
            int stakeId = 1;
            int variantId = 1;

            int firstTableId = tablesService.AddTable(importTable[0], clientId, stakeId, variantId);
            int secondTableId = tablesService.AddTable(importTable[1], clientId, stakeId, variantId);
            int thirdTableId = tablesService.AddTable(importTable[2], clientId, stakeId, variantId);
            List<TableDto> tables = tablesService.GetTableById(firstTableId, secondTableId, thirdTableId).ToList();
            int expected = 3;
            int actual = tables.Count;

            Assert.Equal(expected, actual);
        }

        private ImportTableDto GetTestImportTable()
        {
            ImportTableDto importTable = new ImportTableDto()
            {
                ButtonSeat = 4,
                PlayMoney = true,
                TableName = "Hatshepsut II",
                TableSize = "6-max",
            };

            return importTable;
        }

        private ImportTableDto[] GetTestImportTables()
        {
            ImportTableDto[] importTables = new ImportTableDto[]
            {
                new ImportTableDto()
                {
                    ButtonSeat = 4,
                    PlayMoney = true,
                    TableName = "Hatshepsut II",
                    TableSize = "6-max",
                },
                new ImportTableDto()
                {
                    ButtonSeat = 3,
                    PlayMoney = false,
                    TableName = "Hatshepsut I",
                    TableSize = "6-max",
                },
                new ImportTableDto()
                {
                    ButtonSeat = 2,
                    PlayMoney = true,
                    TableName = "Hatshepsut II",
                    TableSize = "9-max",
                },
            };

            return importTables;
        }
        private Table[] GetTestTables()
        {
            Table[] tables = new Table[]
            {
                new Table()
                {
                    Client = new Client()
                    {
                        Id = 1,
                        Name = "Pokerstars",
                    },
                    ClientId = 1,
                    Id = 1,
                    Name = "Hatshepsut I",
                    Size = 6,
                    Stake = new Stake()
                    {
                        BigBlind = 0.02m,
                        Currency = "USD",
                        CurrencySymbol = '$',
                        Id = 1,
                        SmallBlind = 0.01m,
                    },
                    StakeId = 1,
                    Variant = new Variant()
                    {
                        Id = 1,
                        Limit = "No Limit",
                        Name = "Hold'em",
                    },
                    VariantId = 1,
                },
                new Table()
                {
                    Client = new Client()
                    {
                        Id = 1,
                        Name = "Pokerstars",
                    },
                    ClientId = 1,
                    Id = 2,
                    Name = "Hatshepsut II",
                    Size = 6,
                    Stake = new Stake()
                    {
                        BigBlind = 0.02m,
                        Currency = "USD",
                        CurrencySymbol = '$',
                        Id = 1,
                        SmallBlind = 0.01m,
                    },
                    StakeId = 1,
                    Variant = new Variant()
                    {
                        Id = 1,
                        Limit = "No Limit",
                        Name = "Hold'em",
                    },
                    VariantId = 1,
                },
                new Table()
                {
                    Client = new Client()
                    {
                        Id = 1,
                        Name = "Pokerstars",
                    },
                    ClientId = 1,
                    Id = 3,
                    Name = "Hatshepsut III",
                    Size = 6,
                    Stake = new Stake()
                    {
                        BigBlind = 0.02m,
                        Currency = "USD",
                        CurrencySymbol = '$',
                        Id = 1,
                        SmallBlind = 0.01m,
                    },
                    StakeId = 1,
                    Variant = new Variant()
                    {
                        Id = 1,
                        Limit = "No Limit",
                        Name = "Hold'em",
                    },
                    VariantId = 1,
                }
            };
            return tables;
        }
    }
}
