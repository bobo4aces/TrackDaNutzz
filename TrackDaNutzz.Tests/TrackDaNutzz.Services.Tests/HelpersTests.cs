using System;
using System.Collections.Generic;
using System.Linq;
using TrackDaNutzz.Services.Dtos.BettingActions;
using TrackDaNutzz.Services.Dtos.CollectMoney;
using TrackDaNutzz.Services.Dtos.Hands;
using TrackDaNutzz.Services.Dtos.Import;
using TrackDaNutzz.Services.Dtos.MuckHands;
using TrackDaNutzz.Services.Dtos.Seats;
using TrackDaNutzz.Services.Dtos.ShowCards;
using TrackDaNutzz.Services.Dtos.Summary;
using TrackDaNutzz.Services.Dtos.Tables;
using TrackDaNutzz.Services.Helpers;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class HelpersTests
    {
        //MathOperations Divide(object firstNumber, object secondNumber)
        //Stack CalculateFinalStack(ImportHandDto handDto, SeatInfoDto seatInfoDto)
        [Fact]
        public void TestDivide_WithTwoNumbers_ShouldReturnCorrectResult()
        {
            decimal result = MathOperations.Divide(6, 2);
            decimal expected = 3;
            decimal actual = result;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateFinalStack_WithTestData_ShouldReturnCorrectFinalStack()
        {
            ImportHandDto handDto = this.GetTestImportHand();
            SeatInfoDto seatInfo = handDto.SeatInfoListDto.SeatInfoDtos.FirstOrDefault();
            decimal result = Stack.CalculateFinalStack(handDto, seatInfo);
            decimal expected = 3.99m;
            decimal actual = result;

            Assert.Equal(expected, actual);
        }

        private ImportHandDto GetTestImportHand()
        {
            ImportHandDto importHandDto = new ImportHandDto()
            {
                BettingActionsByRoundListDto = new BettingActionsByRoundListDto()
                {
                    BettingActionsByRoundDtos = new List<BettingActionsByRoundDto>()
                    {
                        new BettingActionsByRoundDto()
                        {
                            BettingActionDtos = new List<BettingActionDto>()
                            {
                                new BettingActionDto()
                                {
                                    Action = "POST SMALL BLIND",
                                    CurrencySymbol = "$",
                                    IsAllIn = false,
                                    PlayerName = "Sigtip",
                                    RaiseTo = null,
                                    Value = 0.01m,
                                }
                            },
                            Round = "PREFLOP"
                        }
                    },

                },
                ShowCardsListDto = new ShowCardsListDto()
                {
                    ShowCardsDtos = new List<ShowCardsDto>()
                    {
                        new ShowCardsDto()
                        {
                            FirstCard = "2s",
                            HandStrength = "a straight, Five to Nine",
                            PlayerName = "Sigtip",
                            SecondCard = "2d",
                        },
                    }
                },
                MuckHandListDto = new MuckHandListDto()
                {
                    MuckHandDtos = new List<MuckHandDto>()
                    {
                        new MuckHandDto()
                        {
                            PlayerName = "Sigtip",
                        }
                    }
                },
                SeatInfoListDto = new SeatInfoListDto()
                {
                    SeatInfoDtos = new List<SeatInfoDto>()
                    {
                        new SeatInfoDto()
                        {
                            CurrencySymbol = "$",
                            Money = 2m,
                            PlayerName = "Sigtip",
                            SeatNumber = 4,
                        }
                    }
                },
                CollectMoneyListDto = new CollectMoneyListDto()
                {
                    CollectMoneyDtos = new List<CollectMoneyDto>()
                    {
                        new CollectMoneyDto()
                        {
                            CurrencySymbol = "$",
                            PlayerName = "Sigtip",
                            Value = 2m,
                        }
                    }
                },
                HandInfoDto = new HandInfoDto()
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
                },
                ImportTableDto = new ImportTableDto()
                {
                    ButtonSeat = 4,
                    PlayMoney = true,
                    TableName = "Hatshepsut II",
                    TableSize = "6-max",
                },
                PotRakeSummaryDto = new PotRakeSummaryDto()
                {
                    CurrencySymbol = "$",
                    Pot = 0.10m,
                    Rake = 0.01m
                },
            };

            return importHandDto;
        }
    }
}
