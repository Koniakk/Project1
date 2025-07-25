using AviaSales.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AviaSales.Service
{
    public class DataContext(string connectionString) : DbContext
    {
        private readonly string ConnectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(builder => builder.Throw(RelationalEventId.MultipleCollectionIncludeWarning));

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Попытаться асинхронно инициализировать сессию.
        ///     Используется для проверки подключения
        ///     и инициализации структуры таблиц.
        /// </summary>
        /// <returns>Статус успешности инициализации.</returns>
        public async Task<bool> TryInitializeAsync()
        {
            var canConnect = await Database.CanConnectAsync();
            var isCreated = await Database.EnsureCreatedAsync();

            return canConnect || isCreated;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Passenger.Configuration());
            builder.ApplyConfiguration(new Ticket.Configuration());
            builder.ApplyConfiguration(new Country.Configuration());
            base.OnModelCreating(builder);
        }

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Passenger> Passengers => Set<Passenger>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Plane> Planes => Set<Plane>();


    }
}