using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Queries.GetRestaurantById;
public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IMapper mapper,IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Restaurant");
        var restaurant = await restaurantsRepository.GetOneAsync(request.Id);
        if (restaurant == null)
            return null;

        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}

