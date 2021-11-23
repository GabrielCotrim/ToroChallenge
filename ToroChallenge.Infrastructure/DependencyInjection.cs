using Microsoft.Extensions.DependencyInjection;
using System;

namespace ToroChallenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
