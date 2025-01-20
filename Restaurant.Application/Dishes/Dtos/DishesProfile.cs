using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Dishes.Dtos;
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
        CreateMap<Dish, DishDto>();
        }
}

