using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories;
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Entities.Restaurantz>> GetAllAsync();
        Task<Entities.Restaurantz?> GetOneAsync(int id);
        Task<int> Create(Restaurantz entity);
        Task Delete(Restaurantz restaurant);
        Task<Restaurantz> UpdateAsync(int id, Restaurantz updatedRestaurant);
    }

