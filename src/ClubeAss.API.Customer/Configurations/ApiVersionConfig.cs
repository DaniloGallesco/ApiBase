using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ClubeAss.API.Customer.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ApiVersionConfig
    {
        public static IServiceCollection ApiVersionServiceConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("x-api-version"),
                                                                new MediaTypeApiVersionReader("x-api-version"));
            });

            // Add ApiExplorer to discover versions
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
            services.AddEndpointsApiExplorer();

            return services;
        }

        public static IApplicationBuilder ApiVersionAppConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc()
               .UseApiVersioning()
               .UseMvcWithDefaultRoute();

            return app;
        }
    }
}

