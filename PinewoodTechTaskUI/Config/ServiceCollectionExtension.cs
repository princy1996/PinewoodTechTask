
using System.Data;

namespace PinewoodTechTaskUI.Config
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfig config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSingleton(config);
            return services;
        }
    }
}
