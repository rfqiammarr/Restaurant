using AutoMapper;
using Restaurant.Application.Restaurants.Command.CreateRestaurant;
using Restaurant.Application.Restaurants.Command.UpdateRestaurant;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Restaurants.Dtos;
public class RestaurantsProfile : Profile // Profile Define Dari Auto Mapper
 {
    public RestaurantsProfile() 
    {

        //Mapping Update Data
        CreateMap<UpdateRestaurantCommand, Restaurantz>();

        // Mapping For Request / Post Data | Dto -> Database
        CreateMap<CreateRestaurantCommand, Restaurantz>()
           .ForMember(d => d.Address, opt => opt.MapFrom(
               src => new Address
               {
                   City = src.City,
                   PostalCode = src.PostalCode,
                   Street = src.Street
               }));

        // Mapping For Response / Get Data | Database -> Dto
        CreateMap<Restaurantz, RestaurantDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes == null ? null : src.Dishes));
    }
}

