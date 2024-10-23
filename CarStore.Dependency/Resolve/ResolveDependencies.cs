using CarStore.Bussines.Services.Implementations;
using CarStore.Bussines.Services.Interfaces;
using CarStore.DataAccess;
using CarStore.Mapper.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace CarStore.Dependency.Resolve
{
    public static class ResolveDependencies
    {
        public static void Resolve(this IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<CarStoreDbContext>();

            // Services
            services.AddScoped<ICarStoreService, CarStoreService>();

            // Mapper
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
