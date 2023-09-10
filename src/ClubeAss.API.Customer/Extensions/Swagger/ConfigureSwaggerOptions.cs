using ClubeAss.API.Customer.Properties;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace ClubeAss.API.Customer.Extensions.Swagger
{
    public class ConfigureSwaggerOptions
        : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Configure each API discovered for Swagger Documentation
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description));
            }
        }

        /// <summary>
        /// Configure Swagger Options. Inherited from the Interface
        /// </summary>
        /// <param name="name"></param>
        /// <param name="options"></param>
        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        /// <summary>
        /// Create information about the version of the API
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Information about the API</returns>
        private OpenApiInfo CreateVersionInfo(
                ApiVersionDescription desc)
        {
            var info = new OpenApiInfo()
            {
                Title = Resources.PROJECT_Name + " Versão: " + desc.ApiVersion.ToString(),
                Version = desc.ApiVersion.ToString(),
                Description = Resources.PROJECT_Description,
                TermsOfService = new Uri(Resources.PROJECT_TermsOfService),
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = Resources.PROJECT_Name + " Versão: " + desc.ApiVersion.ToString(),
                    Email = Resources.PROJECT_Email,
                    Url = new Uri(Resources.PROJECT_TermsOfService),
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = Resources.PROJECT_Copyright,
                    Url = new Uri(Resources.PROJECT_TermsOfService),
                }
            };

            if (desc.IsDeprecated)
            {
                info.Description += Resources.Deprecated;
            }

            return info;
        }
    }
}
