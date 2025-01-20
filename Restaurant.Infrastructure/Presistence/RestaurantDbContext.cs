using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infrastructure.Presistence;
public class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options) // Menggunakan Primary Constructor
{
    internal DbSet<Domain.Entities.Restaurantz> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=data_testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    //}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurantz>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurantz>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);

    }
}

