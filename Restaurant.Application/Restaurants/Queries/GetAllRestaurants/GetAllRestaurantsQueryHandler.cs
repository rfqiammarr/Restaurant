using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
public class GetAllRestaurantsQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Restaurants");

        // Mendapatkan data restaurants dari repository
        var restaurants = await restaurantsRepository.GetAllAsync();

        // Periksa jika data null (opsional, tapi umum untuk GetAll tidak mengembalikan null)
        if (restaurants == null || !restaurants.Any())
        {
            logger.LogWarning("No restaurants found");
            return Enumerable.Empty<RestaurantDto>(); // Mengembalikan koleksi kosong
        }

        // Mapping data dari entitas Restaurant ke Automapper
        var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantDto;
    }
}

