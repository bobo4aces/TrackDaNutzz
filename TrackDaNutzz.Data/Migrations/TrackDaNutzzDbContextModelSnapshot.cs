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
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Action", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT");

                    b.Property<long>("HandId")
                        .HasColumnName("HandId")
                        .HasColumnType("BIGINT");

                    b.Property<bool>("IsAllIn")
                        .HasColumnName("IsAllIn")
                        .HasColumnType("BIT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(17)")
                        .HasMaxLength(17)
                        .IsUnicode(false);

                    b.Property<int>("PlayerId")
                        .HasColumnName("PlayerId")
                        .HasColumnType("INT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("Street")
                        .HasColumnType("VARCHAR(7)")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<decimal?>("Value")
                        .HasColumnName("Value")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.HasIndex("HandId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Board", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Flop")
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

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Hand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BoardId")
                        .HasColumnName("BoardId")
                        .HasColumnType("BIGINT");

                    b.Property<byte>("Button")
                        .HasColumnName("Button")
                        .HasColumnType("TINYINT");

                    b.Property<long>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("BIGINT");

                    b.Property<decimal>("Rake")
                        .HasColumnName("Rake")
                        .HasColumnType("MONEY");

                    b.Property<int>("TableId")
                        .HasColumnName("TableId")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Time")
                        .HasColumnName("Time")
                        .HasColumnType("DATETIME2");

                    b.Property<decimal>("TotalPot")
                        .HasColumnName("TotalPot")
                        .HasColumnType("MONEY");

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

                    b.HasKey("HandId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("HandPlayers");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.HandStatistics", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AggresionFactor")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AggresionFactor")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<decimal>("BigBlindsWon")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnName("BigBlindsWon")
                        .HasColumnType("DECIMAL(15,2)");

                    b.Property<bool>("ContinuationBet")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContinuationBet")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<decimal>("DollarsWon")
                        .HasColumnName("DollarsWon")
                        .HasColumnType("MONEY");

                    b.Property<bool>("FourBet")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FourBet")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<long>("HandId");

                    b.Property<int>("PlayerId");

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

                    b.Property<bool>("VoluntaryPutInPot")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("VoluntaryPutInPot")
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("HandId");

                    b.HasIndex("PlayerId");

                    b.ToTable("HandStatistics");
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
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<decimal>("Stack")
                        .HasColumnName("Stack")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Seat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FinalStack")
                        .HasColumnName("FinalStack")
                        .HasColumnType("MONEY");

                    b.Property<long>("HandId")
                        .HasColumnName("HandId")
                        .HasColumnType("BIGINT");

                    b.Property<string>("HoleCards")
                        .HasColumnName("HoleCards")
                        .HasColumnType("VARCHAR(7)")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<bool>("IsShowCards")
                        .HasColumnName("IsShowCards")
                        .HasColumnType("BIT");

                    b.Property<byte>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("TINYINT");

                    b.Property<int>("PlayerId")
                        .HasColumnName("PlayerId")
                        .HasColumnType("INT");

                    b.Property<decimal>("StartStack")
                        .HasColumnName("StartStack")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.HasIndex("HandId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BigBlind")
                        .HasColumnName("BigBlind")
                        .HasColumnType("MONEY");

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasColumnName("Client")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnName("Currency")
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasColumnName("Format")
                        .HasColumnType("VARCHAR(7)")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("Limit")
                        .IsRequired()
                        .HasColumnName("Limit")
                        .HasColumnType("VARCHAR(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnName("Size")
                        .HasColumnType("VARCHAR(6)")
                        .HasMaxLength(6)
                        .IsUnicode(false);

                    b.Property<decimal>("SmallBlind")
                        .HasColumnName("SmallBlind")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Action", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Hand", "Hand")
                        .WithMany()
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Hand", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Board", "Board")
                        .WithMany()
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Table", "Table")
                        .WithMany("Hands")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.HandStatistics", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Hand", "Hand")
                        .WithMany()
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackDaNutzz.Data.Models.Seat", b =>
                {
                    b.HasOne("TrackDaNutzz.Data.Models.Hand", "Hand")
                        .WithMany()
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackDaNutzz.Data.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
