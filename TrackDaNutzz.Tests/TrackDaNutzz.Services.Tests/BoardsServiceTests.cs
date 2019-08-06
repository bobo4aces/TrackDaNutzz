using Microsoft.EntityFrameworkCore;
using System;
using TrackDaNutzz.Data;
using TrackDaNutzz.Services.Boards;
using TrackDaNutzz.Services.Dtos.Boards;
using TrackDaNutzz.Services.Dtos.Summary;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class BoardsServiceTests
    {
        //long AddBoard(BoardSummaryDto boardSummaryDto);
        //BoardDto GetBoardById(int boardId);
        [Fact]
        public void TestAddBoard_WithOneBoard_ShouldReturnCorrectId()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            BoardsService boardsService = new BoardsService(context);
            BoardSummaryDto boardSummaryDto = GetTestBoardSummaryDto();
            long boardId = boardsService.AddBoard(boardSummaryDto);
            long expected = 1;
            long actual = boardId;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetBoardById_WithOneBoard_ShouldReturnCorrectBoard()
        {
            DbContextOptions<TrackDaNutzzDbContext> options = new DbContextOptionsBuilder<TrackDaNutzzDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            TrackDaNutzzDbContext context = new TrackDaNutzzDbContext(options);

            BoardsService boardsService = new BoardsService(context);
            BoardSummaryDto[] boardSummaryDtos = GetTestTwoBoardSummaryDtos();
            long firstBoardId = boardsService.AddBoard(boardSummaryDtos[0]);
            long secondBoardId = boardsService.AddBoard(boardSummaryDtos[1]);
            BoardDto boardDto = boardsService.GetBoardById(2);
            Assert.NotNull(boardDto);
        }

        private BoardSummaryDto GetTestBoardSummaryDto()
        {
            BoardSummaryDto boardSummaryDto = new BoardSummaryDto()
            {
                FirstCard = "2s",
                SecondCard = "3s",
                ThirdCard = "4s",
                FourthCard = "5s",
                FifthCard = "6s",
            };
            return boardSummaryDto;
        }

        private BoardSummaryDto[] GetTestTwoBoardSummaryDtos()
        {
            BoardSummaryDto[] boardSummaryDtos = new BoardSummaryDto[]
            {
                new BoardSummaryDto()
                {
                    FirstCard = "2s",
                    SecondCard = "3s",
                    ThirdCard = "4s",
                    FourthCard = "5s",
                    FifthCard = "6s",
                },
                new BoardSummaryDto()
                {
                    FirstCard = "2d",
                    SecondCard = "3d",
                    ThirdCard = "4d",
                    FourthCard = "5d",
                    FifthCard = "6d",
                },
            };
            return boardSummaryDtos;
        }
    }
}
