using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentNode.Domain.interfaces;
using TalentNode.Infrastructure.Data;
using TalentNode.Infrastructure.Repositories;

namespace TalentNode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastuctureDI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TalentNodeDbContext>(options => { options.UseSqlServer(connectionString); });

            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IBooking, BookingRepository>();
            return services;
        }
    }
}
