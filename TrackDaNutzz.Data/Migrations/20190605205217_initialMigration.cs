using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackDaNutzz.Data.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flop = table.Column<string>(type: "VARCHAR(11)", unicode: false, maxLength: 11, nullable: false),
                    Turn = table.Column<string>(type: "VARCHAR(3)", unicode: false, maxLength: 3, nullable: true),
                    River = table.Column<string>(type: "VARCHAR(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(10)", unicode: false, maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SmallBlind = table.Column<decimal>(type: "MONEY", nullable: false),
                    BigBlind = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VoluntaryPutMoneyInPot = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    PreFlopRaise = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    ThreeBet = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    FourBet = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    AggressionFactor = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    ContinuationBet = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    BigBlindsWon = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    MoneyWon = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Birthday = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Limit = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    HasAnte = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(30)", unicode: false, maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    ClientId = table.Column<int>(type: "INT", nullable: false),
                    Size = table.Column<byte>(type: "TINYINT", nullable: false),
                    Currency = table.Column<string>(type: "VARCHAR(10)", unicode: false, maxLength: 10, nullable: false),
                    VariantId = table.Column<int>(type: "INT", nullable: false),
                    StakeId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tables_Stakes_StakeId",
                        column: x => x.StakeId,
                        principalTable: "Stakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tables_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<long>(type: "BIGINT", nullable: false),
                    Time = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Button = table.Column<byte>(type: "TINYINT", nullable: false),
                    Pot = table.Column<decimal>(type: "MONEY", nullable: false),
                    Rake = table.Column<decimal>(type: "MONEY", nullable: false),
                    TableId = table.Column<int>(type: "INT", nullable: false),
                    BoardId = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hands_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hands_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HandPlayers",
                columns: table => new
                {
                    HandId = table.Column<long>(type: "BIGINT", nullable: false),
                    PlayerId = table.Column<int>(type: "INT", nullable: false),
                    StartingStack = table.Column<decimal>(type: "MONEY", nullable: false),
                    FinalStack = table.Column<decimal>(type: "MONEY", nullable: false),
                    SeatNumber = table.Column<byte>(type: "TINYINT", nullable: false),
                    HoleCards = table.Column<string>(type: "VARCHAR(7)", unicode: false, maxLength: 7, nullable: true),
                    IsInPosition = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsMuckCards = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    HasShowdown = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsAllIn = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    PositionId = table.Column<int>(type: "INT", nullable: false),
                    StatisticId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandPlayers", x => new { x.HandId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_HandPlayers_Hands_HandId",
                        column: x => x.HandId,
                        principalTable: "Hands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HandPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HandPlayers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HandPlayers_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BettingActions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Round = table.Column<string>(type: "VARCHAR(10)", unicode: false, maxLength: 10, nullable: false),
                    Type = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Value = table.Column<decimal>(type: "MONEY", nullable: true),
                    HandPlayerHandId = table.Column<long>(nullable: true),
                    HandPlayerPlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BettingActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BettingActions_HandPlayers_HandPlayerHandId_HandPlayerPlayerId",
                        columns: x => new { x.HandPlayerHandId, x.HandPlayerPlayerId },
                        principalTable: "HandPlayers",
                        principalColumns: new[] { "HandId", "PlayerId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BettingActions_HandPlayerHandId_HandPlayerPlayerId",
                table: "BettingActions",
                columns: new[] { "HandPlayerHandId", "HandPlayerPlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HandPlayers_PlayerId",
                table: "HandPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_HandPlayers_PositionId",
                table: "HandPlayers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_HandPlayers_StatisticId",
                table: "HandPlayers",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_BoardId",
                table: "Hands",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_TableId",
                table: "Hands",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ClientId",
                table: "Tables",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_StakeId",
                table: "Tables",
                column: "StakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_VariantId",
                table: "Tables",
                column: "VariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BettingActions");

            migrationBuilder.DropTable(
                name: "HandPlayers");

            migrationBuilder.DropTable(
                name: "Hands");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Stakes");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
