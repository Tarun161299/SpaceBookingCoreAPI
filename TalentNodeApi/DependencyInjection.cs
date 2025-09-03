using TalentNode.Application;
using TalentNode.Infrastructure;

namespace TalentNodeApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTalentNodeDI(this IServiceCollection services)
        {
            services.AddApplicationDI().AddInfrastuctureDI();
            return services;
        }
    }
}
