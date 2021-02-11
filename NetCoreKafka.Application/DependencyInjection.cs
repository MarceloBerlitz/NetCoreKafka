using Microsoft.Extensions.DependencyInjection;
using NetCoreKafka.Infrastructure.Messaging;
using System;

namespace NetCoreKafka.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IMyProducer, MyProducer>();
            return services;
        }
    }
}
