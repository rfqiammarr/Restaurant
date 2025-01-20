﻿using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Command.DeleteRestaurant;
public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id: {request.Id}");
        var restaurant = await restaurantsRepository.GetOneAsync(request.Id);
        if (restaurant is null)
            return false;

        await restaurantsRepository.Delete(restaurant);
        return true;
    }
}
