﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Restaurant.Application.Restaurants.Command.DeleteRestaurant;
    public class DeleteRestaurantCommand(int id) : IRequest<bool>
    {
        public int Id { get;} = id;
    }
