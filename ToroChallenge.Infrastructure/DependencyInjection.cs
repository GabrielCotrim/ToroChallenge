using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToroChallenge.Application.Interfaces.Repositories;
using ToroChallenge.Infrastructure.Data;
using ToroChallenge.Infrastructure.Repositories;

namespace ToroChallenge.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    options => {
                        options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        options.EnableRetryOnFailure();
                    });
            });
            services.AddScoped<IPatrimonioRepository, PatrimonioRepository>();
            return services;
        }
    }
}
