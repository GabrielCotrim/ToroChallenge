using Microsoft.Extensions.DependencyInjection;
using System;

namespace ToroChallenge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
