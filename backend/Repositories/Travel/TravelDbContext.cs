using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

public class TravelDbContext : DbContext {
    public TravelDbContext (DbContextOptions<TravelDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().ToTable("Country");

        modelBuilder.Entity<Booking>()
            .Ignore(b => b.CurrentExchangeRate)
            .Ignore(b => b.TotalCostExchange)
            .Ignore(b => b.CostPerDayExchange);
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Booking> Booking { get; set; }

}

