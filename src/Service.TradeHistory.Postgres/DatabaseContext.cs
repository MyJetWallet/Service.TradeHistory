using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<TradeHistoryEntity>().ToTable(TradeHistoryTableName);
            modelBuilder.Entity<TradeHistoryEntity>().HasKey(e => e.TradeId);
            //modelBuilder.Entity<TradeHistoryEntity>().
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => e.WalletId);
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => new {e.WalletId, e.InstrumentSymbol});
            
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => new { e.WalletId, e.SequenceId });
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => new { e.WalletId, e.InstrumentSymbol, e.SequenceId });
            modelBuilder.Entity<TradeHistoryEntity>().HasIndex(e => e.SequenceId);

            //todo: добавить уникальных ключей

            base.OnModelCreating(modelBuilder);
        }
    }
}
