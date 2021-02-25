using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Service.TradeHistory.Postgres
{
    public class DatabaseContext : DbContext
    {
        public const string Schema = "tradehistory";

        public const string TradeHistoryTableName = "trade_history";

        public DbSet<TradeHistoryEntity> Trades { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public static ILoggerFactory LoggerFactory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (LoggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<TradeHistoryEntity>().ToTable(TradeHistoryTableName);
            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.TradeId).UseIdentityColumn();
            modelBuilder.Entity<TradeHistoryEntity>().HasKey(e => e.TradeId);
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => e.TradeUId).IsUnique();

            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => e.TradeUId);
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => e.WalletId);
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => new {e.WalletId, e.InstrumentSymbol});
            
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => new { e.WalletId, e.SequenceId });
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => new { e.WalletId, e.InstrumentSymbol, e.SequenceId });
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => e.SequenceId);

            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.OrderId).HasMaxLength(128);
            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.WalletId).HasMaxLength(128);
            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.ClientId).HasMaxLength(128);
            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.BrokerId).HasMaxLength(128);
            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.InstrumentSymbol).HasMaxLength(64);
            modelBuilder.Entity<TradeHistoryEntity>().Property(e => e.TradeUId).HasMaxLength(128);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> UpsetAsync(IEnumerable<TradeHistoryEntity> entities)
        {
            var result = await Trades.UpsertRange(entities).On(e => e.TradeUId).NoUpdate().RunAsync();
            return result;
        }

        
    }
}
