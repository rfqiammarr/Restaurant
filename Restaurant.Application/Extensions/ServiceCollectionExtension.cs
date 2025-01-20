using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Domain.Repositories;

namespace Restaurant.Application.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddApplication(this IServiceCollection service)
        {
            // Dependency Injection for Service
            var applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            // Daftarkan AutoMapper Profile yang tepat
            //service.AddAutoMapper(typeof(RestaurantsProfile).Assembly);

            // Daftarkan semua AutoMapper Profiles dalam seluruh assembly
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
