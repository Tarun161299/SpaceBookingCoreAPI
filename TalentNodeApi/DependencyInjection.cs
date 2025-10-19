using TalentNode.Application;
using TalentNode.Infrastructure;

namespace TalentNodeApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTalentNodeDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI().AddInfrastuctureDI(configuration);
            return services;
        }
    }
}
