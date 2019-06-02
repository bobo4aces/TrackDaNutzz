using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackDaNutzz.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Flop = table.Column<string>(type: "VARCHAR(11)", unicode: false, maxLength: 11, nullable: true),
                    Turn = table.Column<string>(type: "VARCHAR(3)", unicode: false, maxLength: 3, nullable: true),
                    River = table.Column<string>(type: "VARCHAR(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Stack = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Client = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Size = table.Column<string>(type: "VARCHAR(6)", unicode: false, maxLength: 6, nullable: false),
                    Currency = table.Column<string>(type: "VARCHAR(10)", unicode: false, maxLength: 10, nullable: false),
                    Format = table.Column<string>(type: "VARCHAR(7)", unicode: false, maxLength: 7, nullable: false),
                    Limit = table.Column<string>(type: "VARCHAR(10)", unicode: false, maxLength: 10, nullable: false),
                    SmallBlind = table.Column<decimal>(type: "MONEY", nullable: false),
                    BigBlind = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
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
                    TotalPot = table.Column<decimal>(type: "MONEY", nullable: false),
                    Rake = table.Column<decimal>(type: "MONEY", nullable: false),
                    TableId = table.Column<int>(type: "INT", nullable: false),
                    BoardId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hands_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hands_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(7)", unicode: false, maxLength: 7, nullable: false),
                    PlayerId = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(17)", unicode: false, maxLength: 17, nullable: false),
                    Value = table.Column<decimal>(type: "MONEY", nullable: true),
                    IsAllIn = table.Column<bool>(type: "BIT", nullable: false),
                    HandId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Hands_HandId",
                        column: x => x.HandId,
                        principalTable: "Hands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actions_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HandPlayers",
                columns: table => new
                {
                    HandId = table.Column<long>(type: "BIGINT", nullable: false),
                    PlayerId = table.Column<int>(type: "INT", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<byte>(type: "TINYINT", nullable: false),
                    PlayerId = table.Column<int>(type: "INT", nullable: false),
                    StartStack = table.Column<decimal>(type: "MONEY", nullable: false),
                    FinalStack = table.Column<decimal>(type: "MONEY", nullable: false),
                    HoleCards = table.Column<string>(type: "VARCHAR(7)", unicode: false, maxLength: 7, nullable: true),
                    IsShowCards = table.Column<bool>(type: "BIT", nullable: false),
                    HandId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Hands_HandId",
                        column: x => x.HandId,
                        principalTable: "Hands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_HandId",
                table: "Actions",
                column: "HandId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_PlayerId",
                table: "Actions",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_HandPlayers_PlayerId",
                table: "HandPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_BoardId",
                table: "Hands",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Hands_TableId",
                table: "Hands",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HandId",
                table: "Seats",
                column: "HandId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PlayerId",
                table: "Seats",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "HandPlayers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Hands");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
