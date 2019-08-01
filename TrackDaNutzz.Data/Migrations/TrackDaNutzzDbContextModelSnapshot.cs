﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackDaNutzz.Data;

namespace TrackDaNutzz.Data.Migrations
{
    [DbContext(typeof(TrackDaNutzzDbContext))]
    partial class TrackDaNutzzDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.BettingAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Round")
                        .IsRequired()
                        .HasColumnName("Round")
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<bool>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Type")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.ToTable("BettingActions");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Board", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Flop")
                        .IsRequired()
                        .HasColumnName("Flop")
                        .HasColumnType("VARCHAR(11)")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    b.Property<string>("River")
                        .HasColumnName("River")
                        .HasColumnType("VARCHAR(3)")
                        .HasMaxLength(3)
                        .IsUnicode(false);

                    b.Property<string>("Turn")
                        .HasColumnName("Turn")
                        .HasColumnType("VARCHAR(3)")
                        .HasMaxLength(3)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Hand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BoardId")
                        .HasColumnName("BoardId")
                        .HasColumnType("BIGINT");

                    b.Property<byte>("Button")
                        .HasColumnName("Button")
                        .HasColumnType("TINYINT");

                    b.Property<DateTime>("LocalTime")
                        .HasColumnName("LocalTime")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("LocalTimeZone")
                        .IsRequired()
                        .HasColumnName("LocalTimeZone")
                        .HasColumnType("VARCHAR(3)")
                        .HasMaxLength(3);

                    b.Property<long>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("BIGINT");

                    b.Property<decimal>("Pot")
                        .HasColumnName("Pot")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Rake")
                        .HasColumnName("Rake")
                        .HasColumnType("MONEY");

                    b.Property<int>("TableId")
                        .HasColumnName("TableId")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Time")
                        .HasColumnName("Time")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnName("TimeZone")
                        .HasColumnType("VARCHAR(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("TableId");

                    b.ToTable("Hands");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.HandPlayer", b =>
                {
                    b.Property<long>("HandId")
                        .HasColumnName("HandId")
                        .HasColumnType("BIGINT");

                    b.Property<int>("PlayerId")
                        .HasColumnName("PlayerId")
                        .HasColumnType("INT");

                    b.Property<string>("BettingActionIdsJoinByPipe")
                        .IsRequired()
                        .HasColumnName("BettingActionIdsJoinByPipe")
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("FinalStack")
                        .HasColumnName("FinalStack")
                        .HasColumnType("MONEY");

                    b.Property<bool>("HasShowdown")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("HasShowdown")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<string>("HoleCards")
                        .HasColumnName("HoleCards")
                        .HasColumnType("VARCHAR(7)")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<bool>("IsAllIn")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsAllIn")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsMuckCards")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsMuckCards")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<byte>("SeatNumber")
                        .HasColumnName("SeatNumber")
                        .HasColumnType("TINYINT");

                    b.Property<decimal>("StackDifference")
                        .HasColumnName("StackDifference")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("StartingStack")
                        .HasColumnName("StartingStack")
                        .HasColumnType("MONEY");

                    b.Property<long>("StatisticId")
                        .HasColumnName("StatisticId")
                        .HasColumnType("BIGINT");

                    b.HasKey("HandId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("StatisticId");

                    b.ToTable("HandPlayers");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("TrackDaNutzzUserId")
                        .IsRequired()
                        .HasColumnName("TrackDaNutzzUserId")
                        .HasColumnType("NVARCHAR(450)")
                        .HasMaxLength(450)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("TrackDaNutzzUserId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Stake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BigBlind")
                        .HasColumnName("BigBlind")
                        .HasColumnType("MONEY");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnName("Currency")
                        .HasColumnType("VARCHAR(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CurrencySymbol")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("CurrencySymbol")
                        .HasColumnType("NVARCHAR(2)")
                        .HasMaxLength(2);

                    b.Property<decimal>("SmallBlind")
                        .HasColumnName("SmallBlind")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.ToTable("Stakes");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Statistic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BigBlindsWon")
                        .HasColumnName("BigBlindsWon")
                        .HasColumnType("DECIMAL(15,2)");

                    b.Property<bool>("ContinuationBet")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContinuationBet")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<bool>("FourBet")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FourBet")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<decimal>("MoneyWon")
                        .HasColumnName("MoneyWon")
                        .HasColumnType("MONEY");

                    b.Property<bool>("PreFlopRaise")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PreFlopRaise")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<bool>("ThreeBet")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ThreeBet")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<int>("TotalBets")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TotalBets")
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    b.Property<int>("TotalCalls")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TotalCalls")
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    b.Property<int>("TotalRaises")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TotalRaises")
                        .HasColumnType("INT")
                        .HasDefaultValue(0);

                    b.Property<bool>("VoluntaryPutMoneyInPot")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VoluntaryPutMoneyInPot")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnName("ClientId")
                        .HasColumnType("INT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<byte>("Size")
                        .HasColumnName("Size")
                        .HasColumnType("TINYINT");

                    b.Property<int>("StakeId")
                        .HasColumnName("StakeId")
                        .HasColumnType("INT");

                    b.Property<int>("VariantId")
                        .HasColumnName("VariantId")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("StakeId");

                    b.HasIndex("VariantId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.TrackDaNutzzRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.TrackDaNutzzUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("NVARCHAR(450)")
                        .HasMaxLength(450)
                        .IsUnicode(true);

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthday")
                        .HasColumnName("Birthday")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("NVARCHAR(256)")
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasColumnType("NVARCHAR(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("NVARCHAR(450)")
                        .HasMaxLength(450)
                        .IsUnicode(true);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Limit")
                        .IsRequired()
                        .HasColumnName("Limit")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Hand", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Board", "Board")
                        .WithMany("Hands")
                        .HasForeignKey("BoardId");

                    b.HasOne("TrackDaNutzz.Data.Models.Table", "Table")
                        .WithMany("Hands")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.HandPlayer", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Hand", "Hand")
                        .WithMany("HandPlayers")
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Player", "Player")
                        .WithMany("HandPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Statistic", "Statistic")
                        .WithMany("HandPlayers")
                        .HasForeignKey("StatisticId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Player", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.TrackDaNutzzUser", "TrackDaNutzzUser")
                        .WithMany("Players")
                        .HasForeignKey("TrackDaNutzzUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Table", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Client", "Client")
                        .WithMany("Tables")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Stake", "Stake")
                        .WithMany("Tables")
                        .HasForeignKey("StakeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Variant", "Variant")
                        .WithMany("Tables")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
