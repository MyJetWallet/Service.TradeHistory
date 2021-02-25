﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Service.TradeHistory.Postgres;

namespace Service.TradeHistory.Postgres.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tradehistory")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Service.TradeHistory.Postgres.TradeHistoryEntity", b =>
                {
                    b.Property<long>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("BaseVolume")
                        .HasColumnType("double precision");

                    b.Property<string>("BrokerId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ClientId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("InstrumentSymbol")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("OrderId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<double>("OrderVolume")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("QuoteVolume")
                        .HasColumnType("double precision");

                    b.Property<long>("SequenceId")
                        .HasColumnType("bigint");

                    b.Property<string>("TradeUId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("WalletId")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("TradeId");

                    b.HasIndex("SequenceId");

                    b.HasIndex("TradeUId")
                        .IsUnique();

                    b.HasIndex("WalletId");

                    b.HasIndex("WalletId", "InstrumentSymbol");

                    b.HasIndex("WalletId", "SequenceId");

                    b.HasIndex("WalletId", "InstrumentSymbol", "SequenceId");

                    b.ToTable("trade_history");
                });
#pragma warning restore 612, 618
        }
    }
}
