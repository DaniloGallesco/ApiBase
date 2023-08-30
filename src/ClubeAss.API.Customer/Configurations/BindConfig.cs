using ClubeAss.Domain.Bind;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ClubeAss.API.Customer.Configurations
{
    public static class BindConfig
    {
        public static IServiceCollection BindServiceConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));

            return services;
        }
    }


 
}
