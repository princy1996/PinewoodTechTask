using Microsoft.Data.SqlClient;
using PinewoodTechTaskAPI.Interfaces;
using PinewoodTechTaskAPI.Services;
using System.Data;

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
            services.AddTransient<IDbConnection>((x) => new SqlConnection(config.ConnectionString));
            return services;
        }
    }
}
