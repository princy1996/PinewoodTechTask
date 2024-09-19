using PinewoodTechTaskAPI.Interfaces;
using PinewoodTechTaskAPI.Services;

namespace PinewoodTechTaskAPI.Config
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfig config)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton(config);
            services.AddTransient<ICustomerService, CustomerService>();
            return services;
        }
    }
}
