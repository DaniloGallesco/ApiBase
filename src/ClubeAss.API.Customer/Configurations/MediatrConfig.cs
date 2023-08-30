using ClubeAss.Domain.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using Velinho_API;

namespace ClubeAss.API.Customer.Configurations
{
    public static class MediatrConfig
    {

        public static void AddMediatrConfig(this IServiceCollection services)
        {
            var applicationAssemblyName = "ClubeAss.Domain";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
        }

    }
}
