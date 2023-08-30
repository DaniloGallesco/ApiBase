using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClubeAss.API.Customer.Configurations
{
    public static class HangfireConfig
    {
        public static IServiceCollection HangfireServiceConfig(this IServiceCollection services)
        {

            services.AddHangfire(x => x.UseInMemoryStorage());
            services.AddHangfireServer();

            return services;
        }

        public static IApplicationBuilder AddHangfireConfigureConfig(this IApplicationBuilder app)
        {
#if DEBUG
            app.UseHangfireDashboard("/jobs");
#endif
            return app;
        }
    }
}
