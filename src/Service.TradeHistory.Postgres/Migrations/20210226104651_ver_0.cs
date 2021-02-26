using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Service.TradeHistory.Postgres.Migrations
{
    public partial class ver_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tradehistory");

            migrationBuilder.CreateTable(
                name: "trade_history",
                schema: "tradehistory",
                columns: table => new
                {
                    TradeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrokerId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    WalletId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    InstrumentSymbol = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    BaseVolume = table.Column<double>(type: "double precision", nullable: false),
                    QuoteVolume = table.Column<double>(type: "double precision", nullable: false),
                    OrderId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    OrderVolume = table.Column<double>(type: "double precision", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TradeUId = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Side = table.Column<int>(type: "integer", nullable: false),
                    SequenceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trade_history", x => x.TradeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_SequenceId",
                schema: "tradehistory",
                table: "trade_history",
                column: "SequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_TradeUId",
                schema: "tradehistory",
                table: "trade_history",
                column: "TradeUId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_WalletId",
                schema: "tradehistory",
                table: "trade_history",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_WalletId_InstrumentSymbol",
                schema: "tradehistory",
                table: "trade_history",
                columns: new[] { "WalletId", "InstrumentSymbol" });

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_WalletId_InstrumentSymbol_SequenceId",
                schema: "tradehistory",
                table: "trade_history",
                columns: new[] { "WalletId", "InstrumentSymbol", "SequenceId" });

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_WalletId_SequenceId",
                schema: "tradehistory",
                table: "trade_history",
                columns: new[] { "WalletId", "SequenceId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trade_history",
                schema: "tradehistory");
        }
    }
}
