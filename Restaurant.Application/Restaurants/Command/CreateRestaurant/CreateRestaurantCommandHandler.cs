using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Restaurants.Command.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a New restaurant");

        //Mapper
        var restaurant = mapper.Map<Restaurantz>(request);

        int id = await restaurantsRepository.Create(restaurant);
        return id;
    }
}

