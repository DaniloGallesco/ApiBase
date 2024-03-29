using ClubeAss.API.Customer.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace ClubeAss.API.Customer
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceAppConfig(Configuration);
            services.AddServiceDependencyInjectionConfig(Configuration);
            services.AddServiceHealthcheckConfig(Configuration);
            services.AddServiceSwaggerConfig(Configuration);
            services.AddServiceAutoMapperConfig();
            services.AddMediatrConfig();
            services.AddDatabaseConfig(Configuration);
            services.ApiVersionServiceConfig();
            services.BindServiceConfig(Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.AddConfigureSerilogConfig(env);
            app.AddConfigureAppConfig(env);
            app.ApiVersionAppConfig(env);
            app.AddConfigureHealthcheckConfig(env);
            app.AddConfigureSwaggerConfig(env);
            app.AddConfigurePrometheusConfig(env);

        }
    }
}