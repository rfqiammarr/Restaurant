using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infrastructure.Presistence;

namespace Restaurant.Infrastructure.Repositories;
public class RestaurantsRepository(RestaurantDbContext dbContext) : IRestaurantsRepository
{
    public async Task<IEnumerable<Domain.Entities.Restaurantz>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants
            .Include(r => r.Address)
            .Include(r => r.Dishes)
            .ToListAsync();

        return restaurants;

    }

    public async Task<Domain.Entities.Restaurantz?> GetOneAsync(int id)
    {
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Address)
            .Include(r => r.Dishes)
            .SingleOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }

    public async Task<int> Create(Restaurantz entity)
    {
        dbContext.Restaurants.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task SaveChanges() => dbContext.SaveChangesAsync();

    public async Task Delete(Restaurantz entity)
    {
        dbContext.Remove(entity);
        dbContext.SaveChanges();
    }

    //public async Task<Restaurantz> UpdateAsync(int id, Restaurantz updatedRestaurant)
    //{
    //    // Ambil data restoran yang ada berdasarkan ID
    //    var existingRestaurant = await dbContext.Restaurants
    //        .Include(r => r.Address)
    //        .Include(r => r.Dishes)
    //        .SingleOrDefaultAsync(x => x.Id == id);

    //    if (existingRestaurant == null)
    //    {
    //        // Jika restoran tidak ditemukan, bisa throw exception atau return null
    //        throw new KeyNotFoundException($"Restaurant with Id {id} not found.");
    //    }

    //    // Update properti dari restoran yang ada dengan data yang di-update
    //    existingRestaurant.Name = updatedRestaurant.Name;
    //    existingRestaurant.Description = updatedRestaurant.Description;
    //    existingRestaurant.Address = updatedRestaurant.Address;
    //    existingRestaurant.Dishes = updatedRestaurant.Dishes;
    //    // Jika ada properti lain yang perlu diupdate, bisa ditambahkan di sini

    //    // Save perubahan ke database
    //    dbContext.Restaurants.Update(existingRestaurant);
    //    await dbContext.SaveChangesAsync();

    //    return existingRestaurant;
    //}
}

