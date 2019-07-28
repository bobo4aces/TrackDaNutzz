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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(256)", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                    Value = table.Column<decimal>(type: "MONEY", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BettingActions", x => x.Id);
                });

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
                name: "Stakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Currency = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    CurrencySymbol = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false),
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
                    AggressionFactor = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    ContinuationBet = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    BigBlindsWon = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    MoneyWon = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false),
                    Limit = table.Column<string>(type: "VARCHAR(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(30)", unicode: false, maxLength: 30, nullable: false),
                    TrackDaNutzzUserId = table.Column<string>(type: "NVARCHAR(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_TrackDaNutzzUserId",
                        column: x => x.TrackDaNutzzUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TimeZone = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    LocalTime = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    LocalTimeZone = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HandPlayers",
                columns: table => new
                {
                    HandId = table.Column<long>(type: "BIGINT", nullable: false),
                    PlayerId = table.Column<int>(type: "INT", nullable: false),
                    StartingStack = table.Column<decimal>(type: "MONEY", nullable: false),
                    FinalStack = table.Column<decimal>(type: "MONEY", nullable: false),
                    StackDifference = table.Column<decimal>(type: "MONEY", nullable: false),
                    SeatNumber = table.Column<byte>(type: "TINYINT", nullable: false),
                    HoleCards = table.Column<string>(type: "VARCHAR(7)", unicode: false, maxLength: 7, nullable: true),
                    IsInPosition = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsMuckCards = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    HasShowdown = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    IsAllIn = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    BettingActionIdsJoinByPipe = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
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
                        name: "FK_HandPlayers_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HandPlayers_PlayerId",
                table: "HandPlayers",
                column: "PlayerId");

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
                name: "IX_Players_TrackDaNutzzUserId",
                table: "Players",
                column: "TrackDaNutzzUserId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BettingActions");

            migrationBuilder.DropTable(
                name: "HandPlayers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Hands");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Stakes");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
