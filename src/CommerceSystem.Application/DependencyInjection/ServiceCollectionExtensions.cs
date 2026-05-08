using CommerceSystem.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommerceSystemApplicationLayer(this IServiceCollection services) 
        {
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
