using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TalentNode.Domain.interfaces;
using TalentNode.Infrastructure.Data;
using TalentNode.Infrastructure.Repositories;

namespace TalentNode.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastuctureDI(this IServiceCollection services)
        {
            services.AddDbContext<TalentNodeDbContext>(options => { options.UseSqlServer("Server=148.113.47.114,49884;Database=urbanCafe;User Id=urbanCafe;Password=Mahadevshivv(12);Encrypt=true;TrustServerCertificate=true;"); });

            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IBooking, BookingRepository>();
            return services;
        }
    }
}
