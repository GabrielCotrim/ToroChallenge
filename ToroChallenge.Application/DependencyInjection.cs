using Microsoft.Extensions.DependencyInjection;
using System;
using ToroChallenge.Application.ApplicationServices;
using ToroChallenge.Application.AutoMapper;
using ToroChallenge.Application.Interfaces.ApplicationServices;
using ToroChallenge.Application.Interfaces.Services;
using ToroChallenge.Application.Services;

namespace ToroChallenge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.RegisterAutoMapper();
            services.AddScoped<IPatrimonioService, PatrimonioService>();
            services.AddScoped<IPatrimonioApplicationService, PatrimonioApplicationService>();
            services.AddScoped<IPatrimonioAtivosApplicationService, PatrimonioAtivosApplicationService>();
            services.AddScoped<IPatrimonioAtivosService, PatrimonioAtivosService>();
            services.AddScoped<IAtivoApplicationService, AtivoApplicationService>();
            services.AddScoped<IAtivoService, AtivoService>();
            return services;
        }
    }
}
