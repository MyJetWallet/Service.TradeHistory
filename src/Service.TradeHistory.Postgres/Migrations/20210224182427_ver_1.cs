using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Service.TradeHistory.Postgres.Migrations
{
    public partial class ver_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_trade_history",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "tradehistory",
                table: "trade_history",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "tradehistory",
                table: "trade_history",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "TradeId",
                schema: "tradehistory",
                table: "trade_history",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                schema: "tradehistory",
                table: "trade_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BaseVolume",
                schema: "tradehistory",
                table: "trade_history",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "BrokerId",
                schema: "tradehistory",
                table: "trade_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                schema: "tradehistory",
                table: "trade_history",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InstrumentSymbol",
                schema: "tradehistory",
                table: "trade_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                schema: "tradehistory",
                table: "trade_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OrderVolume",
                schema: "tradehistory",
                table: "trade_history",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                schema: "tradehistory",
                table: "trade_history",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "QuoteVolume",
                schema: "tradehistory",
                table: "trade_history",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "SequenceId",
                schema: "tradehistory",
                table: "trade_history",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TradeNo",
                schema: "tradehistory",
                table: "trade_history",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "WalletId",
                schema: "tradehistory",
                table: "trade_history",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_trade_history",
                schema: "tradehistory",
                table: "trade_history",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_trade_history_SequenceId",
                schema: "tradehistory",
                table: "trade_history",
                column: "SequenceId");

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
            migrationBuilder.DropPrimaryKey(
                name: "PK_trade_history",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropIndex(
                name: "IX_trade_history_SequenceId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropIndex(
                name: "IX_trade_history_WalletId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropIndex(
                name: "IX_trade_history_WalletId_InstrumentSymbol",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropIndex(
                name: "IX_trade_history_WalletId_InstrumentSymbol_SequenceId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropIndex(
                name: "IX_trade_history_WalletId_SequenceId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "TradeId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "BaseVolume",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "DateTime",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "InstrumentSymbol",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "OrderVolume",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "QuoteVolume",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "SequenceId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "TradeNo",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.DropColumn(
                name: "WalletId",
                schema: "tradehistory",
                table: "trade_history");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "tradehistory",
                table: "trade_history",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "tradehistory",
                table: "trade_history",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_trade_history",
                schema: "tradehistory",
                table: "trade_history",
                column: "Id");
        }
    }
}
